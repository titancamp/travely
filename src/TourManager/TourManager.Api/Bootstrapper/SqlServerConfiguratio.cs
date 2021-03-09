using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TourManager.Repository.EfCore.Context;
using Microsoft.Extensions.DependencyInjection;

namespace TourManager.Api.Bootstrapper
{
    public static class SqlServerConfiguration
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TourDbContext>(
               options => options.UseSqlServer(
                       configuration.GetConnectionString("TourDbContext"),
                       x => x.MigrationsAssembly("TourManager.Repository.EfCore.MsSql")));

            return services;
        }
    }
}