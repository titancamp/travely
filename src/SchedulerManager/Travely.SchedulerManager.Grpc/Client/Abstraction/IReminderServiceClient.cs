using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.SchedulerManager.Grpc.Client.Models;

namespace Travely.SchedulerManager.Grpc.Client.Abstraction
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
