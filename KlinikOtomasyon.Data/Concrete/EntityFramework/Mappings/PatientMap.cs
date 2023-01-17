using KlinikOtomasyon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KlinikOtomasyon.Data.Concrete.EntityFramework.Mappings
{
    public class PatientMap : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(150);
            
            builder.Property(p => p.Surname).IsRequired();
            builder.Property(p => p.Surname).HasMaxLength(150);

            builder.Property(p => p.ComingFrom).IsRequired();
            builder.Property(p => p.ComingFrom).HasMaxLength(60);

            builder.Property(p => p.HowFindUs).IsRequired(false);
            builder.Property(p => p.HowFindUs).HasMaxLength(30);

            builder.HasOne(p => p.Clinic).WithMany(c => c.Patients).HasForeignKey(p => p.ClinicId).OnDelete(DeleteBehavior.SetNull).IsRequired(false);

            // Shared
            builder.Property(p => p.CreatedDate).IsRequired();
            
            builder.Property(p => p.ModifiedDate).IsRequired();

            builder.Property(p => p.CreatedByName).IsRequired();
            builder.Property(p => p.CreatedByName).HasMaxLength(50);

            builder.Property(p => p.ModifiedByName).IsRequired();
            builder.Property(p => p.ModifiedByName).HasMaxLength(50);

            builder.Property(p => p.IsActive).IsRequired();

            builder.Property(p => p.IsDeleted).IsRequired();

            builder.Property(p => p.Note).IsRequired(false);
            builder.Property(p => p.Note).HasMaxLength(300);

            builder.ToTable("Patients");

            builder.HasData(
                new Patient
                {
                    Id = 1,
                    Name = "Fake",
                    Surname = "Patient",
                    ComingFrom = "Avustralya",
                    HowFindUs = "Instagram",
                    ClinicId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk Hasta. FluentAPI ile oluşturulmuştur."
                }
            );
        }
    }
}