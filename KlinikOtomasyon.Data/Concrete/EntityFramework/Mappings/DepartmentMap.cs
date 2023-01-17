using KlinikOtomasyon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KlinikOtomasyon.Data.Concrete.EntityFramework.Mappings
{
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedOnAdd();

            builder.Property(d => d.Name).IsRequired();
            builder.Property(d => d.Name).HasMaxLength(40);

            builder.HasOne(d => d.Clinic).WithMany(c => c.Deparments).HasForeignKey(d => d.ClinicId).OnDelete(DeleteBehavior.SetNull).IsRequired(false);

            // Shared
            builder.Property(d => d.CreatedDate).IsRequired();
            
            builder.Property(d => d.ModifiedDate).IsRequired();

            builder.Property(d => d.CreatedByName).IsRequired();
            builder.Property(d => d.CreatedByName).HasMaxLength(50);

            builder.Property(d => d.ModifiedByName).IsRequired();
            builder.Property(d => d.ModifiedByName).HasMaxLength(50);

            builder.Property(d => d.IsActive).IsRequired();

            builder.Property(d => d.IsDeleted).IsRequired();

            builder.Property(d => d.Note).IsRequired(false);
            builder.Property(d => d.Note).HasMaxLength(300);

            builder.ToTable("Departments");

            builder.HasData(
                new Department
                {
                    Id = 1,
                    Name = "Hemşire",
                    ClinicId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk Hemşire Departmanı. FluentAPI ile oluşturulmuştur."
                },

                new Department
                {
                    Id = 2,
                    Name = "Satış",
                    ClinicId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk Satış Departmanı. FluentAPI ile oluşturulmuştur."
                },

                new Department
                {
                    Id = 3,
                    Name = "Tercüman",
                    ClinicId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk Tercüman Departmanı. FluentAPI ile oluşturulmuştur."
                },

                new Department
                {
                    Id = 4,
                    Name = "Masaj",
                    ClinicId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk Masaj Departmanı. FluentAPI ile oluşturulmuştur."
                },
                
                new Department
                {
                    Id = 5,
                    Name = "Hekim",
                    ClinicId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk Hekim Departmanı. FluentAPI ile oluşturulmuştur."
                },

                new Department
                {
                    Id = 6,
                    Name = "Yönetim",
                    ClinicId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk Yönetim Departmanı. FluentAPI ile oluşturulmuştur."
                }
            );
        }
    }
}