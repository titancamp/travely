using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Travely.SchedulerManager.Abstraction.Notifier;
using Travely.SchedulerManager.Notifier.Hubs;

namespace Travely.SchedulerManager.Notifier.Services
{
    class NotifierService : INotifierService
    {
        IHubContext<NotificationHub, INotificationHub> _hubContext;
        public NotifierService(IHubContext<NotificationHub, INotificationHub> hub)
        {
            _hubContext = hub;
        }
        public Task Notify(string userId)
        {
            return _hubContext.Clients.Client(userId).ReceiveNotification(new { message = "Hola" });
        }
    }
}
