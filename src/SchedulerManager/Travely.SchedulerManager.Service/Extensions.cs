using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Travely.SchedulerManager.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IBookingNotificationService, BookingNotificationService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapper());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
