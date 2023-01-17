using KlinikOtomasyon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KlinikOtomasyon.Data.Concrete.EntityFramework.Mappings
{
    public class MassageMap : IEntityTypeConfiguration<Massage>
    {
        public void Configure(EntityTypeBuilder<Massage> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.WherePerformed).IsRequired();
            builder.Property(m => m.WherePerformed).HasMaxLength(50);

            builder.HasOne(m => m.Patient).WithMany(p => p.Massages).HasForeignKey(m => m.PatientId).OnDelete(DeleteBehavior.SetNull).IsRequired(false);

            // Shared
            builder.Property(m => m.CreatedDate).IsRequired();
            
            builder.Property(m => m.ModifiedDate).IsRequired();

            builder.Property(m => m.CreatedByName).IsRequired();
            builder.Property(m => m.CreatedByName).HasMaxLength(50);

            builder.Property(m => m.ModifiedByName).IsRequired();
            builder.Property(m => m.ModifiedByName).HasMaxLength(50);

            builder.Property(m => m.IsActive).IsRequired();

            builder.Property(m => m.IsDeleted).IsRequired();

            builder.Property(m => m.Note).IsRequired(false);
            builder.Property(m => m.Note).HasMaxLength(300);

            builder.ToTable("Massages");

            builder.HasData(
                new Massage
                {
                    Id = 1,
                    WherePerformed = "Otel",
                    PatientId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk Masaj. FluentAPI ile oluşturulmuştur."
                }
            );
        }
    }
}