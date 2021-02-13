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
        
        public override async Task<ActivityResponse> CreateActivity(Activity activity, ServerCallContext context)
        {
            var createdActivity = await _activityManager.CreateActivityAsync(activity);

            return new ActivityResponse
            {
                Message = $"Successfully cerated new activity: {createdActivity.Name}",
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

        public override async Task<ActivityResponse> DeleteActivity(DeleteActivityRequest req, ServerCallContext context)
        {
            return await _activityManager.DeleteActivityAsync(req.ActivityId.Value);
        }

        public override async Task<ActivityResponse> EditActivity(Activity activity, ServerCallContext context)
        {
            var editedActivity = await _activityManager.EditActivityAsync(activity);

            return new ActivityResponse
            {
                Message = $"Successfully updated activity: {editedActivity.Name}",
                Status = ResponseStatus.Success
            };
        }
    }
}
