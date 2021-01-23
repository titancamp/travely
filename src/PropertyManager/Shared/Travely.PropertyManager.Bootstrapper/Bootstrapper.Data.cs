using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Travely.PropertyManager.Data.EntityFramework;

namespace Travely.PropertyManager.Bootstrapper
{
    public static partial class Bootstrapper
    {
        public static void ConfigureDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PropertyDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
