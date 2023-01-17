using KlinikOtomasyon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KlinikOtomasyon.Data.Concrete.EntityFramework.Mappings
{
    public class MassageEmployeeMap : IEntityTypeConfiguration<MassageEmployee>
    {
        public void Configure(EntityTypeBuilder<MassageEmployee> builder)
        {
            builder.HasKey(me => new { me.MassageId, me.UserId });

            builder.HasOne(me => me.Massage).WithMany(m => m.Employees).HasForeignKey(me => me.MassageId);

            builder.HasOne(me => me.User).WithMany(e => e.Massages).HasForeignKey(me => me.UserId);

            builder.ToTable("MassagesEmployees");

            builder.HasData(
                new MassageEmployee
                {
                    MassageId = 1,
                    UserId = 4
                },

                new MassageEmployee
                {
                    MassageId = 1,
                    UserId = 1
                },

                new MassageEmployee
                {
                    MassageId = 1,
                    UserId = 2
                }
            );
        }
    }
}