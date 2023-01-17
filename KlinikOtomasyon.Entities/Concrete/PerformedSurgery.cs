using KlinikOtomasyon.Shared.Entities.Abstract;

namespace KlinikOtomasyon.Entities.Concrete
{
    public class PerformedSurgery : EntityBase, IEntity
    {
        public int? SurgeryId { get; set; }
        public Surgery Surgery { get; set; }
        public string Epicrisis { get; set; }
        public int TakenFatAmount { get; set; } = 0;
        public int GivenFatAmount { get; set; } = 0;
        public int ImplantSize { get; set; } = 0;
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        public int? ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}