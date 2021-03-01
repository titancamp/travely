using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travely.SchedulerManager
{
    public interface IBookingNotificationService
    {
        Task<Notification> GetNotification(long bookingId);

        Task<IEnumerable<Notification>> GetAllNotifications();

        Task<bool> CreateNotification(CreateNotification create);

        Task<bool> UpdateNotification(UpdateNotification update);

        Task<bool> DeleteNotification(long bookingId);
    }
}