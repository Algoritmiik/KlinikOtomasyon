using Microsoft.AspNetCore.Identity;

namespace KlinikOtomasyon.Entities.Concrete
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityNumber { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<MassageEmployee> Massages { get; set; }
        
        //Entity Base 
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual string CreatedByName { get; set; }
        public virtual string ModifiedByName { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual string Note { get; set; }
    }
}