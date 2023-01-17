namespace KlinikOtomasyon.Entities.Dtos.SurgeryDtos
{
    public class ClinicSurgeriesGetterDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int SurgeryPrice { get; set; } = 0;
        public int HospitalPrice { get; set; } = 0;
        public string? SurgeryPriceCurrency { get; set; }
        public string? HospitalPriceCurrency { get; set; }
        public int HospitalDay { get; set; } = 0;
        public int HotelDay { get; set; } = 0;
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual string CreatedByName { get; set; }
        public virtual string ModifiedByName { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Note { get; set; }
    }
}