using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.SchedulerManager.Common.Enums;
using Travely.SchedulerManager.Service;

namespace Travely.SchedulerManager
{
    public interface INotificationService
    {
        Task<NotificationModel> GetNotification(long scheduleId); //TODO-Question: Do we need to return compiled notification?

        Task<IEnumerable<NotificationModel>> GetAllNotifications(); //TODO-Question: Do we need to return compiled notification?

        Task<bool> CreateNotification<T>(T model) where T: INotificationModel;

        Task UpdateNotification<T>(T model) where T : INotificationModel;

        Task DeleteNotification(long scheduleId);

        void SetNotificationStatus(NotificationStatus status, long scheduleId, params long[] userIds);
    }
}