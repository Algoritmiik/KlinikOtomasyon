using KlinikOtomasyon.Entities.Concrete;

namespace KlinikOtomasyon.MVC.Models.ResultModels.Home
{
    public class HomeIndexResultModel
    {
        public List<Patient> Patients { get; set; } = new();
    }
}