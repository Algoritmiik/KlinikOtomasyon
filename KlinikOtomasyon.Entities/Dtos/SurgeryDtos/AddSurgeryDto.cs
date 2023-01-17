namespace KlinikOtomasyon.Entities.Dtos.SurgeryDtos
{
    public class AddSurgeryDto
    {
        public string Name { get; set; }
        public int SurgeryPrice { get; set; } = 0;
        public int HospitalPrice { get; set; } = 0;
        public string SurgeryPriceCurrency { get; set; }
        public string HospitalPriceCurrency { get; set; }
        public int HospitalDay { get; set; } = 0;
        public int HotelDay { get; set; } = 0;
        public bool IsExtra { get; set; } = false;
    }
}