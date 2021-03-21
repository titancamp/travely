using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;

namespace Travely.SchedulerManager.Notifier.Hubs
{
    [Authorize]
    class NotificationHub : Hub<INotificationHub>
    {
        private readonly IDistributedCache _redis;
        public NotificationHub(IDistributedCache cache)
        {
            _redis = cache;
        }
        public override Task OnConnectedAsync()
        {
            _redis.SetStringAsync(Context.GetHttpContext().GetTravelyUserInfo().UserId.ToString(), Context.ConnectionId);
            Groups.AddToGroupAsync(Context.ConnectionId, Context.GetHttpContext().GetTravelyUserInfo().AgencyId.ToString());
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _redis.RemoveAsync(Context.GetHttpContext().GetTravelyUserInfo().UserId.ToString());
            Groups.RemoveFromGroupAsync(Context.ConnectionId, Context.GetHttpContext().GetTravelyUserInfo().AgencyId.ToString());
            return base.OnDisconnectedAsync(exception);
        }
    }

    public interface INotificationHub
    {
        Task ReceiveNotification(NotificationModel model);
    }
}
