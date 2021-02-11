using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travely.ServiceManager.Service
{
    public interface IActivityManager
    {
        Task<int> CreateActivityAsync(Activity activity);
        Task<IEnumerable<Activity>> GetActivitiesAsync(int agencyId);
        Task<ActivityResponce> DeleteActivityAsync(long activityId);
        Task<ActivityResponce> EditActivityAsync(Activity activity);
    }
}
