using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Service.Model.SchedulerManager.Reminders;

namespace TourManager.Clients.Abstraction.SchedulerManager
{
    public interface IReminderServiceClient
    {
        Task<ReminderNotification> GetAsync(int bookingId);

        Task<IEnumerable<ReminderNotification>> GetAllAsync();

        Task<bool> CreateAsync(CreateUpdateReminderRequest request);

        Task<bool> UpdateAsync(CreateUpdateReminderRequest request);

        Task<bool> DeleteAsync(int bookingId);
    }
}
