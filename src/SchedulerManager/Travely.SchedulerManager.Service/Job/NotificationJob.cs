using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Travely.SchedulerManager.Common.Enums;

namespace Travely.SchedulerManager.Service
{
    public class NotificationJob : IAsyncJob<NotificationJobParameter>
    {
        private readonly INotifierService _notifierService;
        private readonly INotificationService _notificationService;

        public NotificationJob(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            _notifierService = scope.ServiceProvider.GetService<INotifierService>();
            _notificationService = scope.ServiceProvider.GetService<INotificationService>();
        }

        public async Task ExecuteAsync(NotificationJobParameter parameter)
        {
            var notificationModel = await _notificationService.GetNotification(parameter.ScheduleId);
            
            var succeededUsers = await _notifierService.NotifyAsync(notificationModel);
            //TODO: delete converting to int when notifier will return list of integers
            var succeededUserIds = succeededUsers.Select(s => Convert.ToInt64(s)).ToList();
            var failedUsers = notificationModel.UserIds.Except(succeededUserIds);

            //Update Users statuses
            _notificationService.SetNotificationStatus(NotificationStatus.Succeeded,  notificationModel.ScheduleId, succeededUserIds.ToArray());
            _notificationService.SetNotificationStatus(NotificationStatus.Failed, notificationModel.ScheduleId, failedUsers.ToArray());
        }
    }
}
