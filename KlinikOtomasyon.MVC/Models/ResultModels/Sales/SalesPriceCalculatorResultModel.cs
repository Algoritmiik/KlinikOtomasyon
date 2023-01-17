namespace KlinikOtomasyon.MVC.Models.ResultModels.Sales
{
    public class SalesPriceCalculatorResultModel
    {
        public List<int> RequestedSurgeriesIds { get; set; } = new();
        public bool hasTransfer { get; set; } = true;
        public bool hasHotel { get; set; } = true;
        public List<int> SeconderOperations { get; set; } = new();
        public bool FriendshipDiscount { get; set; } = false;
        public int HotelPersonNumber { get; set; } = 1;
        public int Total { get; set; } = 0;
    }
}