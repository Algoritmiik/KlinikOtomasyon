using KlinikOtomasyon.Entities.Dtos.SurgeryDtos;

namespace KlinikOtomasyon.MVC.Models.ResultModels.Clinic
{
    public class ClinicSurgeriesResultModel
    {
        public List<ClinicSurgeriesGetterDto> Surgeries { get; set; } = new();
        public AddSurgeryDto AddSurgery { get; set; } = new();
    }
}