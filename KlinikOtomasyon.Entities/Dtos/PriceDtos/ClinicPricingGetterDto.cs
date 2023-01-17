namespace KlinikOtomasyon.Entities.Dtos.PriceDtos
{
    public class ClinicPricingGetterDto
    {
        public int Id { get; set; }
        public string PriceOf { get; set; }
        public int PriceAmount { get; set; }
        public string Currency { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string CreatedByName { get; set; }
        public virtual string ModifiedByName { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Note { get; set; }
    }
}