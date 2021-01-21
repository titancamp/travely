using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Travely.SchedulerManager.Abstraction.Notifier;
using Travely.SchedulerManager.Notifier.Hubs;
using Travely.SchedulerManager.Notifier.Services;

namespace Travely.SchedulerManager.Notifier
{
    public static class Extensions
    {

        public static IServiceCollection AddNotifier(this IServiceCollection services)
        {
            services.AddScoped<INotifierService, NotifierService>();
            services.AddSignalR();
            return services;
        }

        public static IApplicationBuilder UseNotifier(this IApplicationBuilder builder)
        {
            return builder.UseEndpoints(e => e.MapHub<NotificationHub>("/notification"));
        }
    }
}
