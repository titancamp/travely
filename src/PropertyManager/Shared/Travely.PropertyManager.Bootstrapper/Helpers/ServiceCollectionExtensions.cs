using Microsoft.Extensions.DependencyInjection;

namespace Travely.PropertyManager.Bootstrapper.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            Bootstrapper.ConfigureAutoMapper(services);
            return services;
        }

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            Bootstrapper.ConfigureDbContext(services, connectionString);
            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            Bootstrapper.RegisterServices(services);
            return services;
        }
    }
}
