using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travely.SchedulerManager
{
    public interface IBookingNotificationService
    {
        Task<NotificationDTO> GetNotification(long bookingId);

        Task<IEnumerable<NotificationDTO>> GetAllNotifications();

        Task<bool> CreateNotification(CreateNotificationDTO createDTO);

        Task<bool> UpdateNotification(CreateNotificationDTO createDTO);

        Task<bool> DeleteNotification(long bookingId);
    }
}
