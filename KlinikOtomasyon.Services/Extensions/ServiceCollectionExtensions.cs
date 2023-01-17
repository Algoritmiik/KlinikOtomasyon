using KlinikOtomasyon.Data.Concrete.EntityFramework.Contexts;
using KlinikOtomasyon.Data.Concrete.EntityFramework.Repositories;
using KlinikOtomasyon.Entities.Concrete;
using KlinikOtomasyon.Services.Abstract;
using KlinikOtomasyon.Services.Concrete;
using KlinikOtomasyon.Shared.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KlinikOtomasyon.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<KlinikOtomasyonContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            serviceCollection.AddIdentity<User, Role>().AddEntityFrameworkStores<KlinikOtomasyonContext>();

            serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));

            serviceCollection.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            return serviceCollection;
        }
        
    }
}