using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travely.SchedulerManager.Common;
using Travely.SchedulerManager.Notifier.Hubs;
using Travely.SchedulerManager.Notifier.Services;

namespace Travely.SchedulerManager.Notifier.Helpers
{
    public static class Extensions
    {

        public static IServiceCollection AddNotifier(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection(NotifierOptions.Section).Get<NotifierOptions>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddSignalR().AddStackExchangeRedis(options.RedisConnectionString, options =>
            {
                options.Configuration.ChannelPrefix = "Travely";
            });
            services.AddHostedService<Worker>();
            return services;
        }

        public static IApplicationBuilder UseNotifier(this IApplicationBuilder builder)
        {
            return builder.UseEndpoints(e => e.MapHub<NotificationHub>("/notification"));
        }
    }
}
