using KlinikOtomasyon.Entities.Dtos.PriceDtos;

namespace KlinikOtomasyon.MVC.Models.ResultModels.Clinic
{
    public class ClinicPricingResultModel
    {
        public List<ClinicPricingGetterDto> Pricings { get; set; } = new();
        public AddPricingDto AddPricing { get; set; } = new();
    }
}