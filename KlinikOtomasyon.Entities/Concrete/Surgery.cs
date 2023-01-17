using KlinikOtomasyon.Shared.Entities.Abstract;

namespace KlinikOtomasyon.Entities.Concrete
{
    public class Surgery : EntityBase, IEntity
    {
        public string Name { get; set; }
        public int SurgeryPrice { get; set; } = 0;
        public int HospitalPrice { get; set; } = 0;
        public string SurgeryPriceCurrency { get; set; }
        public string HospitalPriceCurrency { get; set; }
        public int HospitalDay { get; set; } = 0;
        public int HotelDay { get; set; } = 0;
        public bool IsExtra { get; set; } = false;
        public int? ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}