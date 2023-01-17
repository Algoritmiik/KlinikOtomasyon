using KlinikOtomasyon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KlinikOtomasyon.Data.Concrete.EntityFramework.Mappings
{
    public class SurgeryMap : IEntityTypeConfiguration<Surgery>
    {
        public void Configure(EntityTypeBuilder<Surgery> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Name).HasMaxLength(60);

            builder.Property(s => s.SurgeryPrice).IsRequired();

            builder.Property(s => s.HospitalPrice).IsRequired();
            
            builder.Property(s => s.SurgeryPriceCurrency).IsRequired();
            builder.Property(s => s.SurgeryPriceCurrency).HasMaxLength(30);

            builder.Property(s => s.HospitalPriceCurrency).IsRequired();
            builder.Property(s => s.HospitalPriceCurrency).HasMaxLength(30);

            builder.Property(s => s.HospitalDay).IsRequired();
            
            builder.Property(s => s.HotelDay).IsRequired();

            builder.HasOne(s => s.Clinic).WithMany(c => c.Surgeries).HasForeignKey(s => s.ClinicId).OnDelete(DeleteBehavior.SetNull).IsRequired(false);

            // Shared
            builder.Property(s => s.CreatedDate).IsRequired();
            
            builder.Property(s => s.ModifiedDate).IsRequired();

            builder.Property(s => s.CreatedByName).IsRequired();
            builder.Property(s => s.CreatedByName).HasMaxLength(50);

            builder.Property(s => s.ModifiedByName).IsRequired();
            builder.Property(s => s.ModifiedByName).HasMaxLength(50);

            builder.Property(s => s.IsActive).IsRequired();

            builder.Property(s => s.IsDeleted).IsRequired();
            
            builder.Property(s => s.IsExtra).IsRequired();

            builder.Property(s => s.Note).IsRequired(false);
            builder.Property(s => s.Note).HasMaxLength(300);

            builder.ToTable("Surgeries");

            builder.HasData(
                new Surgery
                {
                    Id = 1,
                    Name = "BBL (Brazilian Butt Lift)",
                    SurgeryPrice = 2440,
                    HospitalPrice = 1000,
                    SurgeryPriceCurrency = "Euro",
                    HospitalPriceCurrency = "Euro",
                    HospitalDay = 2,
                    HotelDay = 4,
                    ClinicId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    IsExtra = false,
                    Note = "Örnek Ameliyat. FluentAPI ile oluşturulmuştur."
                },

                new Surgery
                {
                    Id = 2,
                    Name = "Rhinoplasty",
                    SurgeryPrice = 2310,
                    HospitalPrice = 1100,
                    SurgeryPriceCurrency = "Euro",
                    HospitalPriceCurrency = "Euro",
                    HospitalDay = 2,
                    HotelDay = 5,
                    ClinicId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    IsExtra = false,
                    Note = "Örnek Ameliyat. FluentAPI ile oluşturulmuştur."
                },

                new Surgery
                {
                    Id = 3,
                    Name = "Chin Implant",
                    SurgeryPrice = 2050,
                    HospitalPrice = 920,
                    SurgeryPriceCurrency = "Euro",
                    HospitalPriceCurrency = "Euro",
                    HospitalDay = 1,
                    HotelDay = 2,
                    ClinicId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    IsExtra = false,
                    Note = "Örnek Ameliyat. FluentAPI ile oluşturulmuştur."
                },

                new Surgery
                {
                    Id = 4,
                    Name = "Facelift",
                    SurgeryPrice = 2810,
                    HospitalPrice = 2000,
                    SurgeryPriceCurrency = "Euro",
                    HospitalPriceCurrency = "Euro",
                    HospitalDay = 2,
                    HotelDay = 5,
                    ClinicId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    IsExtra = false,
                    Note = "Örnek Ameliyat. FluentAPI ile oluşturulmuştur."
                },

                new Surgery
                {
                    Id = 5,
                    Name = "Kol Ekstra Bölge",
                    SurgeryPrice = 300,
                    HospitalPrice = 0,
                    SurgeryPriceCurrency = "Euro",
                    HospitalPriceCurrency = "Euro",
                    HospitalDay = 0,
                    HotelDay = 0,
                    ClinicId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    IsExtra = true,
                    Note = "Örnek Ameliyat. FluentAPI ile oluşturulmuştur."
                }
            );
        }
    }
}