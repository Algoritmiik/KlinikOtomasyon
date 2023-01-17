using KlinikOtomasyon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KlinikOtomasyon.Data.Concrete.EntityFramework.Mappings
{
    public class PriceMap : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.PriceOf).IsRequired();
            builder.Property(p => p.PriceOf).HasMaxLength(70);

            builder.Property(p => p.PriceAmount).IsRequired();

            builder.Property(p => p.Currency).IsRequired();
            builder.Property(p => p.Currency).HasMaxLength(40);

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

            builder.ToTable("Prices");

            builder.HasData(
                new Price
                {
                    Id = 1,
                    PriceOf = "Hotel 1 Kişilik Standart Oda",
                    PriceAmount = 80,
                    Currency = "Euro",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk fiyat. FluentAPI ile oluşturulmuştur."
                }
            );
        }
    }
}