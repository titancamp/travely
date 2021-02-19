using Microsoft.Extensions.DependencyInjection;

namespace TourManager.Api.Bootstrapper
{
    public static class TourManagerDIConfiguration
    {
        public static IServiceCollection AddTourManagerServices(this IServiceCollection services)
        {
            // configure DI for application services

            return services;
        }
    }
}