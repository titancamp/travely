using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.SchedulerManager.Common.Enums;
using Travely.SchedulerManager.Service;

namespace Travely.SchedulerManager
{
    public interface INotificationService
    {
        Task<NotificationGeneratedModel> GetNotification(long tourId, long bookingId, MessageTemplate template); //TODO-Question: Do we need to return compiled notification?
        
        Task<NotificationGeneratedModel> GetNotification(long scheduleId); //TODO-Question: Do we need to return compiled notification?

        Task<IEnumerable<NotificationGeneratedModel>> GetAllNotifications(); //TODO-Question: Do we need to return compiled notification?

        Task<bool> CreateNotification<T>(T model) where T: INotificationModel;

        Task<bool> UpdateNotification<T>(T model) where T : INotificationModel;

        Task<bool> DeleteNotification(long tourId, long bookingId, MessageTemplate template);

        void SetNotificationStatus(NotificationStatus status, long scheduleId, params long[] userIds);
    }
}