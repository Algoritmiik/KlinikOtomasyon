using KlinikOtomasyon.Shared.Entities.Abstract;

namespace KlinikOtomasyon.Entities.Concrete
{
    public class Massage : EntityBase, IEntity
    {
        public string WherePerformed { get; set; }
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        public ICollection<MassageEmployee> Employees { get; set; }
    }
}