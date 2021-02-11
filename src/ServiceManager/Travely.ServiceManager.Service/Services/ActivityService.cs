using Grpc.Core;
using System.Threading.Tasks;

namespace Travely.ServiceManager.Service
{
    public class ActivityService : ActivityProto.ActivityProtoBase
    {
        private readonly IActivityManager _activityManager;

        public ActivityService(IActivityManager activityManager)
        {
            _activityManager = activityManager;
        }
        
        public override async Task<ActivityResponce> CreateActivity(Activity activity, ServerCallContext context)
        {
            var activityId = await _activityManager.CreateActivityAsync(activity);

            return new ActivityResponce
            {
                Message = $"Successfully cerated new activity: {activity.Name}",
                Status = ResponseStatus.Success
            };
        }

        public override async Task<Activities> GetActivities(GetActivitiesRequest req, ServerCallContext context)
        {
            var allActivities = await _activityManager.GetActivitiesAsync(req.AgencyId);

            var activities = new Activities();
            activities.Activities_.AddRange(allActivities);
            
            return activities;
        }

        public override async Task<ActivityResponce> DeleteActivity(DeleteActivityRequest req, ServerCallContext context)
        {
            return await _activityManager.DeleteActivityAsync(req.ActivityId.Value);
        }


        public override async Task<ActivityResponce> EditActivity(Activity activity, ServerCallContext context)
        {
            return await _activityManager.EditActivityAsync(activity);
        }
    }
}
