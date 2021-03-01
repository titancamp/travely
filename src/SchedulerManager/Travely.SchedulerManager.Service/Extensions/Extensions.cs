using Microsoft.Extensions.DependencyInjection;
using Travely.SchedulerManager.Service.Helpers;

namespace Travely.SchedulerManager.Service.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingNotificationService, BookingNotificationService>();
            services.AddAutoMapper(typeof(MapperProfile));

            return services;
        }
    }
}