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
                await _sp.CreateScope().ServiceProvider
                  .GetRequiredService<IHubContext<NotificationHub, INotificationHub>>()
                  .Clients.All
                  .ReceiveNotification(new Random().Next());
                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}
