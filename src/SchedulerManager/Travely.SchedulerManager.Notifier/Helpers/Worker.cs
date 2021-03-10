using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Travely.SchedulerManager.Notifier.Hubs;

namespace Travely.SchedulerManager.Notifier.Helpers
{
    class Worker : BackgroundService
    {
        readonly IServiceProvider _sp;
        public Worker(IServiceProvider serviceProvider)
        {
            _sp = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _sp.CreateScope();
                var notificationHub = scope.ServiceProvider.GetRequiredService<IHubContext<NotificationHub, INotificationHub>>();
                await notificationHub.Clients.All.ReceiveNotification(new NotificationModel { Message = "Hola" });
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
