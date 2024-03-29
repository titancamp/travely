﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travely.ServiceManager.Grpc.Client.Abstarction
{
    public interface IServiceManagerClient
    {
        Task<ActivityResponse> CreateActivityAsync(Activity activity);
        Task<ActivityResponse> EditActivityAsync(Activity activity);
        Task<ActivityResponse> DeleteActivityAsync(long activityId);
        Task<IEnumerable<Activity>> GetActivitiesAsync(long agencyId);
        Task<IEnumerable<ActivityType>> SearchActivityTypesAsync(long agencyId, string activityTypeName);
        Task<ActivityType> CreateActivityType(long agencyId, string activityTypeName);
    }
}
