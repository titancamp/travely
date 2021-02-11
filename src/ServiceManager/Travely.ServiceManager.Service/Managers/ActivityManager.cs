using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travely.ServiceManager.Service.Managers
{
    public class ActivityManager : IActivityManager
    {
        public Task<int> CreateActivity(Activity activity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Activity>> GetActivities(int agencyId)
        {
            throw new NotImplementedException();
        }

        public Task<ActivityResponce> DeleteActivity(long activityId)
        {
            throw new NotImplementedException();
        }

        public Task<ActivityResponce> EditActivity(Activity activity)
        {
            throw new NotImplementedException();
        }
    }
}
