using System.Threading.Tasks;
using Travely.SchedulerManager.Common;

namespace Travely.SchedulerManager
{
    public interface INotificationService
    {
        Task NotifyAsync(NotificationInfo dto);
    }
}
