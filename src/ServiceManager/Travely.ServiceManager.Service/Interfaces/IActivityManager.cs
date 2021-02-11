using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travely.ServiceManager.Service
{
    public interface IActivityManager
    {
        Task<int> CreateActivity(Activity activity);
        Task<IEnumerable<Activity>> GetActivities(int agencyId);
        Task<ActivityResponce> DeleteActivity(long activityId);
        Task<ActivityResponce> EditActivity(Activity activity);
    }
}
