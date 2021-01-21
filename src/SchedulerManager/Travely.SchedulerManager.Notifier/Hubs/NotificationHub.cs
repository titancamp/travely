using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Travely.SchedulerManager.Notifier.Hubs
{
    class NotificationHub : Hub<INotificationHub>
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }

    public interface INotificationHub
    {
        Task ReceiveNotification(object obj);
    }
}
