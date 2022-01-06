using Microsoft.Extensions.DependencyInjection;
using TourManager.Service.Abstraction;
using TourManager.Service.Implementation;

namespace TourManager.Api.Bootstrapper
{
    public static class TourManagerDIConfiguration
    {
        public static IServiceCollection AddTourManagerServices(this IServiceCollection services)
        {
            services.AddScoped<ITourService, TourService>();
            services.AddScoped<IBookingService, BookingService>();

            return services;
        }
    }
}