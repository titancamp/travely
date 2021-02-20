using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travely.SchedulerManager.Notifier.Hubs;
using Travely.SchedulerManager.Notifier.Services;

namespace Travely.SchedulerManager.Notifier.Helpers
{
    public static class Extensions
    {

        public static IServiceCollection AddNotifier(this IServiceCollection services, string connString)
        {
            services.AddScoped<INotificationService, NotificationService>();
            services.AddSignalR().AddStackExchangeRedis(connString, options =>
            {
                options.Configuration.ChannelPrefix = "Travely";
            });
            services.AddHostedService<Worker>();
            return services;
        }
        public static IServiceCollection ConfigureEmailing(this IServiceCollection services, IConfigurationSection section)
        {
            services.Configure<EmailOptions>(section);
            return services;
        }

        public static IApplicationBuilder UseNotifier(this IApplicationBuilder builder)
        {
            return builder.UseEndpoints(e => e.MapHub<NotificationHub>("/notification"));
        }
    }
}
