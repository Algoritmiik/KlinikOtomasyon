using KlinikOtomasyon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KlinikOtomasyon.Data.Concrete.EntityFramework.Mappings
{
    public class ClinicMap : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100);

            // Shared
            builder.Property(c => c.CreatedDate).IsRequired();
            
            builder.Property(c => c.ModifiedDate).IsRequired();

            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);

            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);

            builder.Property(c => c.IsActive).IsRequired();

            builder.Property(c => c.IsDeleted).IsRequired();

            builder.Property(c => c.Note).IsRequired(false);
            builder.Property(c => c.Note).HasMaxLength(300);

            builder.ToTable("Clinics");

            builder.HasData(
                new Clinic
                {
                    Id = 1,
                    Name = "Trioklinik",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk klinik. FluentAPI ile oluşturulmuştur."
                }
            );
        }
    }
}