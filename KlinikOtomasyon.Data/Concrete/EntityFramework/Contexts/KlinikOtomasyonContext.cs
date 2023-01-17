using KlinikOtomasyon.Data.Concrete.EntityFramework.Mappings;
using KlinikOtomasyon.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KlinikOtomasyon.Data.Concrete.EntityFramework.Contexts
{
    public class KlinikOtomasyonContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public KlinikOtomasyonContext(DbContextOptions<KlinikOtomasyonContext> options) : base(options)
        {
        }

        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Massage> Massages { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PerformedSurgery> PerformedSurgeries { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Surgery> Surgeries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClinicMap());
            modelBuilder.ApplyConfiguration(new DepartmentMap());
            modelBuilder.ApplyConfiguration(new MassageEmployeeMap());
            modelBuilder.ApplyConfiguration(new MassageMap());
            modelBuilder.ApplyConfiguration(new PatientMap());
            modelBuilder.ApplyConfiguration(new PaymentMap());
            modelBuilder.ApplyConfiguration(new PerformedSurgeryMap());
            modelBuilder.ApplyConfiguration(new PriceMap());
            modelBuilder.ApplyConfiguration(new SurgeryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new RoleClaimMap());
            modelBuilder.ApplyConfiguration(new UserClaimMap());
            modelBuilder.ApplyConfiguration(new UserLoginMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.ApplyConfiguration(new UserTokenMap());
        }
    }
}