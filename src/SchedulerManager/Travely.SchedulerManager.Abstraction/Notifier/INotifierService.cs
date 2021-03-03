using System.Threading.Tasks;
using Travely.SchedulerManager.Common;

namespace Travely.SchedulerManager
{
    public interface INotifierService
    {
        Task<string> NotifyAsync(NotificationModel model);
    }
}
