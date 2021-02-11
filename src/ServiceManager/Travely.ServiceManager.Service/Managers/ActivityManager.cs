using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travely.ServiceManager.Service.Managers
{
    public class ActivityManager : IActivityManager
    {
        public Task<int> CreateActivityAsync(Activity activity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Activity>> GetActivitiesAsync(int agencyId)
        {
            throw new NotImplementedException();
        }

        public Task<ActivityResponce> DeleteActivityAsync(long activityId)
        {
            throw new NotImplementedException();
        }

        public Task<ActivityResponce> EditActivityAsync(Activity activity)
        {
            throw new NotImplementedException();
        }
    }
}
