using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travely.SchedulerManager
{
    public interface IBookingNotificationService
    {
        Task<NotificationDTO> GetNotification(long bookingId);

        Task<IEnumerable<NotificationDTO>> GetAllNotifications();

        Task<bool> CreateNotification(CreateNotificationDTO createDto);

        Task<bool> UpdateNotification(UpdateNotificationDTO createDTO);

        Task<bool> DeleteNotification(long bookingId);
    }
}