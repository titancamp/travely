using System;
using System.Threading.Tasks;

namespace Travely.SchedulerManager.Service
{
    public class NotificationJob : IAsyncJob<NotificationJobParameter>
    {
        private readonly INotifierService _notifierService;
        private readonly INotificationService _notificationService;

        public NotificationJob(INotifierService notifierService, INotificationService notificationService)
        {
            _notifierService = notifierService;
            _notificationService = notificationService;
        }

        public async Task ExecuteAsync(NotificationJobParameter parameter)
        {
            var notificationModel = await _notificationService.GetNotification(parameter.ScheduleId);
            var statusResponse = await _notifierService.NotifyAsync(notificationModel);
            //TODO: Update schedule users statuses
            //_notificationService.UpdateNotification(statusResponse);
        }
    }
}
