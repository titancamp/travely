using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Travely.PropertyManager.Data.EntityFramework;
using Travely.PropertyManager.Data.Contracts.Repositories;
using Travely.PropertyManager.Data.Repositories;

namespace Travely.PropertyManager.Bootstrapper
{
    public static partial class Bootstrapper
    {
        public static void ConfigureDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PropertyDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IPropertyRepository, PropertyRepository>();
        }
    }
}
