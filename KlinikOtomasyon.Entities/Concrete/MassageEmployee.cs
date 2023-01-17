using KlinikOtomasyon.Shared.Entities.Abstract;

namespace KlinikOtomasyon.Entities.Concrete
{
    public class MassageEmployee : IEntity
    {
        public int MassageId { get; set; }
        public Massage Massage { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}