using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.ServiceManager.Abstraction.Interfaces.UnitOfWorks;

namespace Travely.ServiceManager.Service.Managers
{
    public class ActivityManager : IActivityManager
    {
        protected readonly IUnitOfWork _unitOfWork;

        public ActivityManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
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
