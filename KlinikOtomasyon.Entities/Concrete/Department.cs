using KlinikOtomasyon.Shared.Entities.Abstract;

namespace KlinikOtomasyon.Entities.Concrete
{
    public class Department : EntityBase, IEntity
    {
        public string Name { get; set; }
        public int? ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public List<User> Users { get; set; }
    }
}