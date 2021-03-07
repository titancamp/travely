using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travely.SchedulerManager
{
    public interface INotifierService
    {
        Task<IEnumerable<string>> NotifyAsync(NotificationModel model);
    }
}
