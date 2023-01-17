using KlinikOtomasyon.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KlinikOtomasyon.Data.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            
            // NonDefault Props
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(50);
            
            builder.Property(e => e.Surname).IsRequired();
            builder.Property(e => e.Surname).HasMaxLength(50);

            builder.Property(e => e.PhoneNumber).IsRequired();
            builder.Property(e => e.PhoneNumber).HasMaxLength(12); //905372306093

            builder.Property(e => e.IdentityNumber).IsRequired();
            builder.Property(e => e.IdentityNumber).HasMaxLength(11);

            builder.HasOne<Department>(e => e.Department).WithMany(d => d.Users).HasForeignKey(e => e.DepartmentId).OnDelete(DeleteBehavior.SetNull).IsRequired(false);

            builder.Property(e => e.CreatedDate).IsRequired();
            
            builder.Property(e => e.ModifiedDate).IsRequired();

            builder.Property(e => e.CreatedByName).IsRequired();
            builder.Property(e => e.CreatedByName).HasMaxLength(50);

            builder.Property(e => e.ModifiedByName).IsRequired();
            builder.Property(e => e.ModifiedByName).HasMaxLength(50);

            builder.Property(e => e.IsActive).IsRequired();

            builder.Property(e => e.IsDeleted).IsRequired();

            builder.Property(e => e.Note).IsRequired(false);
            builder.Property(e => e.Note).HasMaxLength(300);

            builder.ToTable("Users");

            var hasher = new PasswordHasher<User>();
            builder.HasData(
                new User
                {
                    Id = 1,
                    UserName = "marslan",
                    NormalizedUserName = "MARSLAN",
                    Email = "metearslan@deneme.com",
                    NormalizedEmail = "metearslan@deneme.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "metearslan123"),
                    SecurityStamp = string.Empty,
                    Name = "Mete",
                    Surname = "Arslan",
                    PhoneNumber = "905344236576",
                    IdentityNumber = "12345678912",
                    DepartmentId = 3,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk tercüman. FluentAPI ile oluşturulmuştur."
                },

                new User
                {
                    Id = 2,
                    UserName = "nozmen",
                    NormalizedUserName = "NOZMEN",
                    Email = "nurcanozmen@deneme.com",
                    NormalizedEmail = "nurcanozmen@deneme.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "nurcanozmen123"),
                    SecurityStamp = string.Empty,
                    Name = "Nurcan",
                    Surname = "Özmen",
                    PhoneNumber = "905344236597",
                    IdentityNumber = "12345678912",
                    DepartmentId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk hemşire. FluentAPI ile oluşturulmuştur."
                },

                new User
                {
                    Id = 3,
                    UserName = "ksarkli",
                    NormalizedUserName = "KSARKLI",
                    Email = "karinsarkli@deneme.com",
                    NormalizedEmail = "karinsarkli@deneme.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "karinsarkli123"),
                    SecurityStamp = string.Empty,
                    Name = "Karin",
                    Surname = "Şarklı",
                    PhoneNumber = "905344236598",
                    IdentityNumber = "12345678912",
                    DepartmentId = 2,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk satış elemanı. FluentAPI ile oluşturulmuştur."
                },

                new User
                {
                    Id = 4,
                    UserName = "bkucukozen",
                    NormalizedUserName = "BKUCUKOZEN",
                    Email = "betulkucukozen@deneme.com",
                    NormalizedEmail = "betulkucukozen@deneme.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "betulkucukozen123"),
                    SecurityStamp = string.Empty,
                    Name = "Betül",
                    Surname = "Küçüközen",
                    PhoneNumber = "905344236599",
                    IdentityNumber = "12345678912",
                    DepartmentId = 4,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk masaj elemanı. FluentAPI ile oluşturulmuştur."
                },

                new User
                {
                    Id = 5,
                    UserName = "corman",
                    NormalizedUserName = "CORMAN",
                    Email = "cagdasorman@deneme.com",
                    NormalizedEmail = "cagdasorman@deneme.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "cagdasorman123"),
                    SecurityStamp = string.Empty,
                    Name = "Çağdaş",
                    Surname = "Orman",
                    PhoneNumber = "905344236595",
                    IdentityNumber = "12345678912",
                    DepartmentId = 5,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk hekim. FluentAPI ile oluşturulmuştur."
                },

                new User
                {
                    Id = 6,
                    UserName = "koozsicak",
                    NormalizedUserName = "KOOZSICAK",
                    Email = "kemalogulcanozsicak@deneme.com",
                    NormalizedEmail = "kemalogulcanozsicak@deneme.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "kemalogulcanozsicak123"),
                    SecurityStamp = string.Empty,
                    Name = "Kemal Oğulcan",
                    Surname = "Özsıcak",
                    PhoneNumber = "905344236594",
                    IdentityNumber = "12345678912",
                    DepartmentId = 6,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk yönetici. FluentAPI ile oluşturulmuştur."
                },

                new User
                {
                    Id = 7,
                    UserName = "maslan",
                    NormalizedUserName = "MASLAN",
                    Email = "mertcanaslan@deneme.com",
                    NormalizedEmail = "mertcanaslan@deneme.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "mertcanaslan123"),
                    SecurityStamp = string.Empty,
                    Name = "Mertcan",
                    Surname = "Aslan",
                    PhoneNumber = "905344236594",
                    IdentityNumber = "12345678912",
                    DepartmentId = 6,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    IsActive = true,
                    IsDeleted = false,
                    Note = "İlk yönetici. FluentAPI ile oluşturulmuştur."
                }
            );
        }
    }
}