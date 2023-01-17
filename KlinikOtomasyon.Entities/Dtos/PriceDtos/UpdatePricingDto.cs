namespace KlinikOtomasyon.Entities.Dtos.PriceDtos
{
    public class UpdatePricingDto
    {
        public int Id { get; set; }
        public string? PriceOf { get; set; }
        public int PriceAmount { get; set; } = 0;
        public string? Currency { get; set; }
        public string? Note { get; set; }
    }
}