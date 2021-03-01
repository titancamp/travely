using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travely.ServiceManager.Service
{
    public interface IActivityManager
    {
        Task<Activity> CreateActivity(Activity activity);
        Task<IEnumerable<Activity>> GetActivitiesAsync(long agencyId);
        Task DeleteActivityAsync(long activityId);
        Activity EditActivity(Activity activity);
        Task<List<ActivityType>> SearchActivityTypesAsync(long agenctId, string activityTypeName);
    }
}
