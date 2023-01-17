using KlinikOtomasyon.Shared.Entities.Abstract;

namespace KlinikOtomasyon.Entities.Concrete
{
    public class Price : EntityBase, IEntity
    {
        public string PriceOf { get; set; }
        public int PriceAmount { get; set; }
        public string Currency { get; set; }
    }
}