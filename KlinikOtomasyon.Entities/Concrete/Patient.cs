using KlinikOtomasyon.Shared.Entities.Abstract;

namespace KlinikOtomasyon.Entities.Concrete
{
    public class Patient : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ComingFrom { get; set; }
        public string HowFindUs { get; set; }
        public int? ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public List<PerformedSurgery> Surgeries { get; set; }
        public List<Massage> Massages { get; set; }
        public List<Payment> Payments { get; set; }
    }
}