using KlinikOtomasyon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KlinikOtomasyon.Data.Concrete.EntityFramework.Mappings
{
    public class PerformedSurgeryMap : IEntityTypeConfiguration<PerformedSurgery>
    {
        public void Configure(EntityTypeBuilder<PerformedSurgery> builder)
        {
            builder.HasKey(ps => ps.Id);
            builder.Property(ps => ps.Id).ValueGeneratedOnAdd();

            builder.HasOne(ps => ps.Surgery).WithMany().HasForeignKey(ps => ps.SurgeryId).OnDelete(DeleteBehavior.SetNull).IsRequired(false);

            builder.Property(ps => ps.Epicrisis).IsRequired(false);
            builder.Property(ps => ps.Epicrisis).HasMaxLength(150);

            builder.Property(ps => ps.TakenFatAmount).IsRequired();

            builder.Property(ps => ps.GivenFatAmount).IsRequired();

            builder.Property(ps => ps.ImplantSize).IsRequired();

            builder.HasOne(ps => ps.Patient).WithMany(p => p.Surgeries).HasForeignKey(ps => ps.PatientId).OnDelete(DeleteBehavior.SetNull).IsRequired(false);

            builder.HasOne(ps => ps.Clinic).WithMany(c => c.PerformedSurgeries).HasForeignKey(ps => ps.ClinicId).OnDelete(DeleteBehavior.SetNull).IsRequired(false);

            // Shared
            builder.Property(ps => ps.CreatedDate).IsRequired();
            
            builder.Property(ps => ps.ModifiedDate).IsRequired();

            builder.Property(ps => ps.CreatedByName).IsRequired();
            builder.Property(ps => ps.CreatedByName).HasMaxLength(50);

            builder.Property(ps => ps.ModifiedByName).IsRequired();
            builder.Property(ps => ps.ModifiedByName).HasMaxLength(50);

            builder.Property(ps => ps.IsActive).IsRequired();

            builder.Property(ps => ps.IsDeleted).IsRequired();

            builder.Property(ps => ps.Note).IsRequired(false);
            builder.Property(ps => ps.Note).HasMaxLength(300);

            builder.ToTable("PerformedSurgeries");

            builder.HasData(
                new PerformedSurgery
                {
                    Id = 1,
                    SurgeryId = 1,
                    Epicrisis = "...",
                    TakenFatAmount = 2500,
                    GivenFatAmount = 800,
                    ImplantSize = 0,
                    PatientId = 1,
                    ClinicId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk Yapılan Ameliyat. FluentAPI ile oluşturulmuştur."
                }
            );
        }
    }
}