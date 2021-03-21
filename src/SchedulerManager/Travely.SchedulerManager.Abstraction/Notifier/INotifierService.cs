using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travely.SchedulerManager
{
    public interface INotifierService
    {
        Task<IEnumerable<long>> NotifyAsync(NotificationModel model);
    }
}
