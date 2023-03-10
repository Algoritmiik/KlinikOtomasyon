using KlinikOtomasyon.Entities.Concrete;
using KlinikOtomasyon.Entities.Dtos.PriceDtos;
using KlinikOtomasyon.Entities.Dtos.SurgeryDtos;
using KlinikOtomasyon.MVC.Models.ResultModels.Clinic;
using KlinikOtomasyon.Services.Abstract;
using KlinikOtomasyon.Shared.Utilities.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KlinikOtomasyon.MVC.Controllers
{
    public class ClinicController : Controller
    {
        private readonly IGenericService<Price> _priceManager;
        private readonly IGenericService<Surgery> _surgeryManager;
        public ClinicController(IGenericService<Price> priceManager, IGenericService<Surgery> surgeryManager)
        {
            _priceManager = priceManager;
            _surgeryManager = surgeryManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());
        }

        #region Surgery Actions
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Surgeries()
        {
            var getSurgeries = await _surgeryManager.GetAllByNonDeletedAsync();
            if (getSurgeries.ResultStatus == ResultStatus.SUCCESS)
            {
                ClinicSurgeriesResultModel clinicSurgeriesResultModel = new ClinicSurgeriesResultModel();
                var surgeriesByDescendingToModifiedDate = getSurgeries.Datas.OrderByDescending(s => s.ModifiedDate);
                foreach (var surgery in surgeriesByDescendingToModifiedDate)
                {
                    clinicSurgeriesResultModel.Surgeries.Add(
                        new ClinicSurgeriesGetterDto
                        {
                            Id = surgery.Id,
                            Name = surgery.Name,
                            SurgeryPrice = surgery.SurgeryPrice,
                            SurgeryPriceCurrency = surgery.SurgeryPriceCurrency,
                            HospitalPrice = surgery.HospitalPrice,
                            HospitalPriceCurrency = surgery.HospitalPriceCurrency,
                            HospitalDay = surgery.HospitalDay,
                            HotelDay = surgery.HotelDay,
                            ModifiedDate = surgery.ModifiedDate,
                            ModifiedByName = surgery.ModifiedByName,
                            CreatedByName = surgery.CreatedByName,
                            CreatedDate = surgery.CreatedDate,
                            IsActive = surgery.IsActive,
                            Note = surgery.Note
                        }
                    );
                }
                return await Task.Run(() => View(clinicSurgeriesResultModel));
            }
            else
            {
                TempData["ErrorMessage"] = $"Ameliyatlar getirilirken bir hatayla kar????la????ld??!";
                return await Task.Run(() => RedirectToAction("Error", "Home"));
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> AddSurgery(ClinicSurgeriesResultModel addSurgeryDto)
        {
            var addSurgery = await _surgeryManager.AddAsync(
                new Surgery
                {
                    Name = addSurgeryDto.AddSurgery.Name,
                    SurgeryPrice = addSurgeryDto.AddSurgery.SurgeryPrice,
                    SurgeryPriceCurrency = addSurgeryDto.AddSurgery.SurgeryPriceCurrency,
                    HospitalPrice = addSurgeryDto.AddSurgery.HospitalPrice,
                    HospitalPriceCurrency = addSurgeryDto.AddSurgery.HospitalPriceCurrency,
                    HospitalDay = addSurgeryDto.AddSurgery.HospitalDay,
                    HotelDay = addSurgeryDto.AddSurgery.HotelDay,
                    ModifiedDate = DateTime.Now,
                    ModifiedByName = "Y??netim",
                    CreatedDate = DateTime.Now,
                    CreatedByName = "Y??netim",
                    IsActive = true,
                    IsDeleted = false,
                    IsExtra = addSurgeryDto.AddSurgery.IsExtra,
                    ClinicId = 1,
                    Note = "Y??netim taraf??ndan olu??turulmu?? ameliyat"
                }
            );
            if (addSurgery.ResultStatus == ResultStatus.SUCCESS)
            {
                TempData["SuccessMessage"] = $"Ameliyat Ba??ar??yla Eklendi!";
                return await Task.Run(() => RedirectToAction("Surgeries", "Clinic"));
            }
            TempData["ErrorMessage"] = $"Ameliyat Eklenirken Bir Hata ??le Kar????la????ld??!";
            return await Task.Run(() => RedirectToAction("Surgeries", "Clinic"));
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteSurgery(int id)
        {
            var getSurgery = await _surgeryManager.GetByIdAsync(id);
            if (getSurgery.ResultStatus == ResultStatus.SUCCESS)
            {
                var deleteSurgery = await _surgeryManager.HardDeleteAsync(getSurgery.Data.Id);
                if (deleteSurgery.ResultStatus == ResultStatus.SUCCESS)
                {
                    TempData["SuccessMessage"] = $"Ameliyat Ba??ar??yla Silindi!";
                    return await Task.Run(() => RedirectToAction("Surgeries", "Clinic"));
                }
                TempData["ErrorMessage"] = $"Ameliyat silinirken bir hatayla kar????la????ld??!";
                return await Task.Run(() => RedirectToAction("Error", "Home"));
            }
            else
            {
                TempData["ErrorMessage"] = $"Ameliyat silinirken bir hatayla kar????la????ld??!";
                return await Task.Run(() => RedirectToAction("Error", "Home"));
            }
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> UpdateSurgery(int id = 0)
        {
            if (id == 0)
            {
                TempData["ErrorMessage"] = $"Bir hata ile kar????la????ld??!";
                return await Task.Run(() => RedirectToAction("Surgeries", "Clinic"));
            }

            var getSurgery = await _surgeryManager.GetByIdAsync(id);
            if (getSurgery.ResultStatus == ResultStatus.SUCCESS)
            {
                return await Task.Run(() => View(new ClinicUpdateSurgeryResultModel
                {
                    UpdateSurgeryDto = new UpdateSurgeryDto
                    {
                        Id = getSurgery.Data.Id,
                        Name = getSurgery.Data.Name,
                        HospitalDay = getSurgery.Data.HospitalDay,
                        HospitalPrice = getSurgery.Data.HospitalPrice,
                        HospitalPriceCurrency = getSurgery.Data.HospitalPriceCurrency,
                        SurgeryPrice = getSurgery.Data.SurgeryPrice,
                        SurgeryPriceCurrency = getSurgery.Data.SurgeryPriceCurrency,
                        HotelDay = getSurgery.Data.HotelDay,
                        Note = getSurgery.Data.Note,
                    }
                }));
            }
            else
            {
                TempData["ErrorMessage"] = $"Bir hata ile kar????la????ld??!";
                return await Task.Run(() => RedirectToAction("Surgeries", "Clinic"));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> UpdateSurgery(UpdateSurgeryDto updateSurgeryDto)
        {
            var getSurgery = await _surgeryManager.GetByIdAsync(updateSurgeryDto.Id);
            if (getSurgery.ResultStatus == ResultStatus.SUCCESS)
            {
                var updateSurgery = await _surgeryManager.UpdateAsync(
                    new Surgery
                    {
                        Id = getSurgery.Data.Id,
                        Name = updateSurgeryDto.Name,
                        HospitalDay = updateSurgeryDto.HospitalDay,
                        HospitalPrice = updateSurgeryDto.HospitalPrice,
                        HospitalPriceCurrency = updateSurgeryDto.HospitalPriceCurrency,
                        SurgeryPrice = updateSurgeryDto.SurgeryPrice,
                        SurgeryPriceCurrency = updateSurgeryDto.SurgeryPriceCurrency,
                        HotelDay = updateSurgeryDto.HotelDay,
                        ModifiedDate = DateTime.Now,
                        ModifiedByName = "Y??netim",
                        IsActive = getSurgery.Data.IsActive,
                        IsDeleted = false,
                        CreatedDate = getSurgery.Data.CreatedDate,
                        CreatedByName = getSurgery.Data.CreatedByName,
                        Note = updateSurgeryDto.Note,
                        ClinicId = getSurgery.Data.ClinicId
                    }
                );
                if (updateSurgery.ResultStatus == ResultStatus.SUCCESS)
                {
                    TempData["SuccessMessage"] = $"Ameliyat Ba??ar??yla G??ncellendi!";
                    return await Task.Run(() => View(new ClinicUpdateSurgeryResultModel
                    {
                        UpdateSurgeryDto = updateSurgeryDto
                    }));
                }
                TempData["ErrorMessage"] = $"Ameliyat g??ncellenirken bir hatayla kar????la????ld??!1";
                return await Task.Run(() => RedirectToAction("Error", "Home"));
            }
            else
            {
                TempData["ErrorMessage"] = $"Ameliyat g??ncellenirken bir hatayla kar????la????ld??!2";
                return await Task.Run(() => RedirectToAction("Error", "Home"));
            }
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> ChangeSurgeryActiveStatus(int id = 0)
        {
            if (id == 0)
            {
                TempData["ErrorMessage"] = $"Bir hata ile kar????la????ld??!";
                return await Task.Run(() => RedirectToAction("Surgeries", "Clinic"));
            }

            var getSurgery = await _surgeryManager.GetByIdAsync(id);
            if (getSurgery.ResultStatus == ResultStatus.SUCCESS)
            {
                getSurgery.Data.IsActive = !getSurgery.Data.IsActive;
                var updateSurgery = await _surgeryManager.UpdateAsync(getSurgery.Data);
                if (updateSurgery.ResultStatus == ResultStatus.SUCCESS)
                {
                    TempData["SuccessMessage"] = $"Aktiflik durumu ba??ar??yla g??ncellendi!";
                    return await Task.Run(() => RedirectToAction("Surgeries", "Clinic"));
                }
                else
                {
                    TempData["ErrorMessage"] = $"Aktiflik durumu g??ncellenirken bir hata ile kar????la????ld??!";
                    return await Task.Run(() => RedirectToAction("Surgeries", "Clinic"));
                }
            }
            else
            {
                TempData["ErrorMessage"] = $"Bir hata ile kar????la????ld??!";
                return await Task.Run(() => RedirectToAction("Surgeries", "Clinic"));
            }
        }
        #endregion

        #region Pricing Actions
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Pricing()
        {
            var getPrices = await _priceManager.GetAllByNonDeletedAsync();
            if (getPrices.ResultStatus == ResultStatus.SUCCESS)
            {
                ClinicPricingResultModel clinicPricingResultModel = new ClinicPricingResultModel();
                var pricesByDescendingToModifiedDate = getPrices.Datas.OrderByDescending(p => p.ModifiedDate);
                foreach (var price in pricesByDescendingToModifiedDate)
                {
                    clinicPricingResultModel.Pricings.Add(
                        new ClinicPricingGetterDto
                        {
                            Id = price.Id,
                            PriceOf = price.PriceOf,
                            PriceAmount = price.PriceAmount,
                            Currency = price.Currency,
                            CreatedByName = price.CreatedByName,
                            CreatedDate = price.CreatedDate,
                            ModifiedByName = price.ModifiedByName,
                            ModifiedDate = price.ModifiedDate,
                            IsActive = price.IsActive,
                            Note = price.Note
                        }
                    );
                }
                return await Task.Run(() => View(clinicPricingResultModel));
            }
            else
            {
                TempData["ErrorMessage"] = $"Fiyatlar getirilirken bir hatayla kar????la????ld??!";
                return await Task.Run(() => RedirectToAction("Error", "Home"));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> AddPricing(ClinicPricingResultModel addPricingDto)
        {
            var addPrice = await _priceManager.AddAsync(
                new Price
                {
                    PriceOf = addPricingDto.AddPricing.PriceOf,
                    PriceAmount = Convert.ToInt32(addPricingDto.AddPricing.PriceAmount),
                    Currency = addPricingDto.AddPricing.Currency,
                    CreatedByName = User.Identity.IsAuthenticated ? User.Identity.Name : "Y??netim",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = User.Identity.IsAuthenticated ? User.Identity.Name : "Y??netim",
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    Note = "Y??netim taraf??ndan olu??turulmu?? fiyatland??rma"
                });

            if (addPrice.ResultStatus == ResultStatus.SUCCESS)
            {
                TempData["SuccessMessage"] = $"Fiyatland??rma Ba??ar??yla Eklendi!";
                return await Task.Run(() => RedirectToAction("Pricing", "Clinic"));
            }
            TempData["ErrorMessage"] = $"Fiyatland??rma Eklenirken Bir Hata ??le Kar????la????ld??!";
            return await Task.Run(() => RedirectToAction("Pricing", "Clinic"));
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeletePricing(int id)
        {
            var getPrice = await _priceManager.GetByIdAsync(id);
            if (getPrice.ResultStatus == ResultStatus.SUCCESS)
            {
                var deletePrice = await _priceManager.HardDeleteAsync(getPrice.Data.Id);
                if (deletePrice.ResultStatus == ResultStatus.SUCCESS)
                {
                    TempData["SuccessMessage"] = $"Fiyatland??rma Ba??ar??yla Silindi!";
                    return await Task.Run(() => RedirectToAction("Pricing", "Clinic"));
                }
                TempData["ErrorMessage"] = $"Fiyat silinirken bir hatayla kar????la????ld??!";
                return await Task.Run(() => RedirectToAction("Error", "Home"));
            }
            else
            {
                TempData["ErrorMessage"] = $"Fiyat silinirken bir hatayla kar????la????ld??!";
                return await Task.Run(() => RedirectToAction("Error", "Home"));
            }
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> UpdatePricing(int id = 0)
        {
            if (id == 0)
            {
                TempData["ErrorMessage"] = $"Bir hata ile kar????la????ld??!";
                return await Task.Run(() => RedirectToAction("Pricing", "Clinic"));
            }

            var getPricing = await _priceManager.GetByIdAsync(id);
            if (getPricing.ResultStatus == ResultStatus.SUCCESS)
            {
                return await Task.Run(() => View(new ClinicUpdatePricingResultModel
                {
                    UpdatePricingDto = new UpdatePricingDto
                    {
                        Id = getPricing.Data.Id,
                        PriceOf = getPricing.Data.PriceOf,
                        PriceAmount = getPricing.Data.PriceAmount,
                        Currency = getPricing.Data.Currency,
                        Note = getPricing.Data.Note
                    }
                }));
            }
            else
            {
                TempData["ErrorMessage"] = $"Bir hata ile kar????la????ld??!";
                return await Task.Run(() => RedirectToAction("Pricing", "Clinic"));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> UpdatePricing(UpdatePricingDto updatePricingDto)
        {
            var getPricing = await _priceManager.GetByIdAsync(updatePricingDto.Id);
            if (getPricing.ResultStatus == ResultStatus.SUCCESS)
            {
                var updatePricing = await _priceManager.UpdateAsync(
                    new Price
                    {
                        Id = getPricing.Data.Id,
                        PriceOf = updatePricingDto.PriceOf,
                        PriceAmount = updatePricingDto.PriceAmount,
                        Currency = updatePricingDto.Currency,
                        Note = updatePricingDto.Note,
                        ModifiedDate = DateTime.Now,
                        ModifiedByName = "Y??netim",
                        CreatedDate = getPricing.Data.CreatedDate,
                        CreatedByName = getPricing.Data.CreatedByName,
                        IsActive = getPricing.Data.IsActive,
                        IsDeleted = getPricing.Data.IsDeleted
                    }
                );
                if (updatePricing.ResultStatus == ResultStatus.SUCCESS)
                {
                    TempData["SuccessMessage"] = $"Fiyat Ba??ar??yla G??ncellendi!";
                    return await Task.Run(() => View(new ClinicUpdatePricingResultModel
                    {
                        UpdatePricingDto = updatePricingDto
                    }));
                }
                TempData["ErrorMessage"] = $"Fiyat g??ncellenirken bir hatayla kar????la????ld??!1";
                return await Task.Run(() => RedirectToAction("Error", "Home"));
            }
            else
            {
                TempData["ErrorMessage"] = $"Fiyat g??ncellenirken bir hatayla kar????la????ld??!2";
                return await Task.Run(() => RedirectToAction("Error", "Home"));
            }
        }
        #endregion
    }
}