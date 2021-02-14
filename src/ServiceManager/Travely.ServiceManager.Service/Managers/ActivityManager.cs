using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travely.ServiceManager.Service.Managers
{
    public class ActivityManager : IActivityManager
    {
        public Task<Activity> CreateActivityAsync(Activity activity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Activity>> GetActivitiesAsync(int agencyId)
        {
            throw new NotImplementedException();
        }

        public Task<ActivityResponse> DeleteActivityAsync(long activityId)
        {
            throw new NotImplementedException();
        }

        public Task<Activity> EditActivityAsync(Activity activity)
        {
            throw new NotImplementedException();
        }
    }
}
