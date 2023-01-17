using KlinikOtomasyon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KlinikOtomasyon.Data.Concrete.EntityFramework.Mappings
{
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Currency).IsRequired();
            builder.Property(p => p.Currency).HasMaxLength(15);

            builder.Property(p => p.WhatFor).IsRequired();
            builder.Property(p => p.WhatFor).HasMaxLength(60);

            builder.Property(p => p.IsCash).IsRequired();

            builder.HasOne(p => p.Patient).WithMany(p => p.Payments).HasForeignKey(p => p.PatientId).OnDelete(DeleteBehavior.SetNull).IsRequired(false);

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

            builder.ToTable("Payments");

            builder.HasData(
                new Payment
                {
                    Id = 1,
                    Price = 3500,
                    Currency = "Euro",
                    WhatFor = "Ameliyat",
                    IsCash = true,
                    PatientId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk Ödeme. FluentAPI ile oluşturulmuştur."
                }
            );
        }
    }
}