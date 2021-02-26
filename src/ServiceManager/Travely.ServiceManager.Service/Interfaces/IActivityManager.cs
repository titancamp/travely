using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travely.ServiceManager.Service
{
    public interface IActivityManager
    {
        Task<Activity> CreateActivityAsync(Activity activity);
        Task<IEnumerable<Activity>> GetActivitiesAsync(long agencyId);
        Task DeleteActivityAsync(long activityId);
        Activity EditActivity(Activity activity);
    }
}
