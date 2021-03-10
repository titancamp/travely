using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;

namespace Travely.SchedulerManager.Notifier.Hubs
{
    // [Authorize]
    class NotificationHub : Hub<INotificationHub>
    {
        private readonly IDistributedCache _redis;
        public NotificationHub(IDistributedCache cache)
        {
            _redis = cache;
        }
        public override Task OnConnectedAsync()
        {
            // _redis.SetStringAsync(Context.UserIdentifier, Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            // _redis.RemoveAsync(Context.UserIdentifier);
            return base.OnDisconnectedAsync(exception);
        }
    }

    public interface INotificationHub
    {
        Task ReceiveNotification(NotificationModel model);
    }
}
