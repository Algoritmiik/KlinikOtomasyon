namespace KlinikOtomasyon.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual string CreatedByName { get; set; }
        public virtual string ModifiedByName { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual string Note { get; set; }
    }
}