using KlinikOtomasyon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KlinikOtomasyon.Data.Concrete.EntityFramework.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(
                new UserRole
                {
                    UserId = 1,
                    RoleId = 7
                },

                new UserRole
                {
                    UserId = 2,
                    RoleId = 2
                },

                new UserRole
                {
                    UserId = 3,
                    RoleId = 4
                },

                new UserRole
                {
                    UserId = 4,
                    RoleId = 6
                },

                new UserRole
                {
                    UserId = 5,
                    RoleId = 5
                },

                new UserRole
                {
                    UserId = 6,
                    RoleId = 3
                },

                new UserRole
                {
                    UserId = 7,
                    RoleId = 1
                }
            );
        }
    }
}