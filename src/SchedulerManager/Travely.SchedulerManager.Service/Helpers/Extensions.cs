using Microsoft.Extensions.DependencyInjection;

namespace Travely.SchedulerManager.Service.Helpers
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