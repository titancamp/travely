using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

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
            var statusResponse = await _notifierService.NotifyAsync(notificationModel);
            //TODO: Update schedule users statuses
            //_notificationService.UpdateNotification(statusResponse);
        }
    }
}
