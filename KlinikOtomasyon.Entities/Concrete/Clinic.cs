using KlinikOtomasyon.Shared.Entities.Abstract;

namespace KlinikOtomasyon.Entities.Concrete
{
    public class Clinic : EntityBase, IEntity
    {
        public string Name { get; set; }
        public List<Patient> Patients { get; set; }
        public List<Surgery> Surgeries { get; set; }
        public List<PerformedSurgery> PerformedSurgeries { get; set; }
        public List<Department> Deparments { get; set; }
    }
}