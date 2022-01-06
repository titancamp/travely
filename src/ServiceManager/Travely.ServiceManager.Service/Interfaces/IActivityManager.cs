using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.ServiceManager.Grpc;

namespace Travely.ServiceManager.Service
{
    public interface IActivityManager
    {
        Task<Activity> CreateActivityAsync(Activity activity);
        Task<IEnumerable<Activity>> GetActivitiesAsync(long agencyId);
        Task DeleteActivityAsync(long activityId);
        Task<Activity> EditActivityAsync(Activity activity);
        Task<List<ActivityType>> SearchActivityTypesAsync(long agenctId, string activityTypeName);
    }
}
