using KlinikOtomasyon.Entities.Concrete;
using KlinikOtomasyon.MVC.Models.ResultModels.Sales;
using KlinikOtomasyon.Services.Abstract;
using KlinikOtomasyon.Shared.Utilities.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KlinikOtomasyon.MVC.Controllers
{
    [Authorize(Roles = "Admin,Manager,Sales")]
    public class SalesController : Controller
    {
        private readonly IGenericService<Surgery> _surgeryManager;
        private readonly IGenericService<Price> _priceManager;
        public SalesController(IGenericService<Surgery> surgeryManager, IGenericService<Price> priceManager)
        {
            _surgeryManager = surgeryManager;
            _priceManager = priceManager;
        }

        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> PriceCalculator()
        {
            var getSurgeries = await _surgeryManager.GetAllByNonDeletedAsync();
            if (getSurgeries.ResultStatus == ResultStatus.SUCCESS)
            {
                ViewBag.SurgeryList = new SelectList(getSurgeries.Datas, "Id", "Name");
                return await Task.Run(() => View());
            }
            TempData["ErrorMessage"] = $"İstediğiniz sayfaya giderken bir hatayla karşılaşıldı!";
            return await Task.Run(() => RedirectToAction("Error", "Home"));
        }

        [HttpPost]
        public async Task<IActionResult> PriceCalculator(SalesPriceCalculatorResultModel salesPriceCalculatorResultModel)
        {
            if (salesPriceCalculatorResultModel.RequestedSurgeriesIds.Count <= 0)
            {
                TempData["ErrorMessage"] = $"Yanlış seçim yaptığınız için fiyat hesaplanamadı!";
                return await Task.Run(() => RedirectToAction("PriceCalculator", "Sales"));
            }
            var result = await CalculateAsync(salesPriceCalculatorResultModel);
            TempData["SuccessMessage"] = $"{result}";
            return await Task.Run(() => RedirectToAction("PriceCalculator", "Sales"));
        }

        ///<summary>
        ///Ücret Hesaplama Fonksiyonu
        ///</summary>
        ///<param name="salesPriceCalculatorResultModel">Gerekli parametreleri dönen model içerisinden çeker</param>
        ///<returns>Hesaplama Sonucunu Int Olarak Döndürür</returns>
        private async Task<int> CalculateAsync(SalesPriceCalculatorResultModel salesPriceCalculatorResultModel)
        {
            List<Surgery> surgeries = new List<Surgery>();
            int total = 0;
            int hotelNumberPrice = 0;
            int transferPrice = 0;
            int combineDiscountPercantage = 0;

            foreach (var surgeryId in salesPriceCalculatorResultModel.RequestedSurgeriesIds)
            {
                var getSurgery = await _surgeryManager.GetByIdAsync(surgeryId);
                if (getSurgery.ResultStatus == ResultStatus.SUCCESS)
                {
                    surgeries.Add(getSurgery.Data);
                }
                else
                {
                    return 1;
                }
            }

            if (salesPriceCalculatorResultModel.hasHotel)
            {
                var getHotelNumberPrice = await _priceManager.GetAllAsync(p => p.PriceOf == $"Otel {salesPriceCalculatorResultModel.HotelPersonNumber} Kişilik Standart Oda");
                if (getHotelNumberPrice.ResultStatus != ResultStatus.SUCCESS)
                    return 2;
                hotelNumberPrice = getHotelNumberPrice.Datas.FirstOrDefault().PriceAmount;
            }

            if(salesPriceCalculatorResultModel.hasTransfer)
            {
                var getTransferPrice = await _priceManager.GetAllAsync(p => p.PriceOf == $"Transfer");
                if (getTransferPrice.ResultStatus != ResultStatus.SUCCESS)
                    return 7;
                transferPrice = getTransferPrice.Datas.FirstOrDefault().PriceAmount;
            }

            var getHospitalDayPrice = await _priceManager.GetAllAsync(p => p.PriceOf == $"Hastane Gecelik Fiyat");
            if (getHospitalDayPrice.ResultStatus != ResultStatus.SUCCESS)
                return 3;
            var hospitalDayPrice = getHospitalDayPrice.Datas.FirstOrDefault().PriceAmount;

            if (surgeries.Count > 1)
            {
                var getCombineDiscountPercantage = await _priceManager.GetAllAsync(p => p.PriceOf == $"Kombine Ameliyat İndirimi");
                if (getCombineDiscountPercantage.ResultStatus != ResultStatus.SUCCESS)
                    return 4;
                combineDiscountPercantage = getCombineDiscountPercantage.Datas.FirstOrDefault().PriceAmount;
                //FIXME: İndirimlerin Yüzdelik Olup Olmadıklarını Otomatik Kontrol Ettir Ve ona Göre İndirim Yap!
            }

            var getSeconderOpsPrice = await _priceManager.GetAllAsync(p => p.PriceOf == $"Sekonder Ameliyat");
            if (getSeconderOpsPrice.ResultStatus != ResultStatus.SUCCESS)
                return 6;
            var seconderOpsPrice = getSeconderOpsPrice.Datas.FirstOrDefault().PriceAmount;


            // İlk sırada en pahalı ameliyatı bulabilmek için ameliyatların toplam fiyatını hesaplayıp sonra sıralama yapmamız gerekiyor!
            for (int i = 0; i < surgeries.Count; i++)
            {
                surgeries[i].SurgeryPrice = surgeries[i].SurgeryPrice + surgeries[i].HospitalPrice + (surgeries[i].HospitalDay * hospitalDayPrice) + (surgeries[i].HotelDay * hotelNumberPrice);
                if (!surgeries[i].IsExtra)
                    surgeries[i].SurgeryPrice += transferPrice;
            }
            surgeries = surgeries.OrderByDescending(s => s.SurgeryPrice).ToList();
            //----------------------------------------------------------------------------------------

            total += surgeries[0].SurgeryPrice;

            // Diğer ameliyatların yüzdeli indirimini buluyor ve toplama ekliyor!
            for (int i = 1; i < surgeries.Count; i++)
            {
                if (surgeries[i].IsExtra) //Ekstra bölgeler indirim almayacağından atlıyor!
                {
                    total += surgeries[i].SurgeryPrice;
                    continue;
                }

                surgeries[i].SurgeryPrice = surgeries[i].SurgeryPrice - (surgeries[i].SurgeryPrice * combineDiscountPercantage / 100);
                total += surgeries[i].SurgeryPrice;
            }
            //----------------------------------------------------------------------------------------

            total += salesPriceCalculatorResultModel.SeconderOperations.Count * seconderOpsPrice;
            
            if (salesPriceCalculatorResultModel.FriendshipDiscount)
            {
                var getFriendshipDiscountPercantage = await _priceManager.GetAllAsync(p => p.PriceOf == $"Arkadaşlık İndirimi");
                if (getFriendshipDiscountPercantage.ResultStatus != ResultStatus.SUCCESS)
                    return 5;
                var friendshipDiscountPercantage = getFriendshipDiscountPercantage.Datas.FirstOrDefault().PriceAmount;

                total -= total * friendshipDiscountPercantage / 100;
            }

            return total;
        }
    }
}