using System.Threading.Tasks;

namespace Travely.SchedulerManager
{
    public interface INotificationService
    {
        Task NotifyAsync(string userId);
    }
}
