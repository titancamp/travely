using Grpc.Core;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Travely.ServiceManager.Service
{
    public class ActivityService : ActivityProto.ActivityProtoBase
    {
        private readonly IActivityManager _activityManager;

        public ActivityService(IActivityManager activityManager)
        {
            _activityManager = activityManager ?? throw new ArgumentNullException(nameof(activityManager));
        }

        public override async Task<ActivityResponse> CreateActivity(Activity activity, ServerCallContext context)
        {
            try
            {
                var createdActivity = await _activityManager.CreateActivityAsync(activity);
                return new ActivityResponse
                {
                    Message = $"Successfully created new activity: {createdActivity?.Name}",
                    Status = ResponseStatus.Success
                };
            }
            catch (Exception ex)
            {
                return new ActivityResponse
                {
                    Message = $"Failed to create new activity: Activity = {JsonConvert.SerializeObject(activity)}, Error = {ex.Message}",
                    Status = ResponseStatus.Failed
                };
            }

        }

        public override async Task<Activities> GetActivities(GetActivitiesRequest req, ServerCallContext context)
        {
            try
            {
                var allActivities = await _activityManager.GetActivitiesAsync(req.AgencyId);

                var activities = new Activities();
                activities.Activities_.AddRange(allActivities);

                return activities;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public override async Task<ActivityResponse> DeleteActivity(DeleteActivityRequest req, ServerCallContext context)
        {
            try
            {
                await _activityManager.DeleteActivityAsync(req.ActivityId);
                return new ActivityResponse
                {
                    Message = $"Successfully deleted given activity: {req.ActivityId}",
                    Status = ResponseStatus.Success
                };
            }
            catch (Exception ex)
            {
                return new ActivityResponse
                {
                    Message = $"Failed to delete given activity: ActivityId = {req.ActivityId}, Error = {ex.Message}",
                    Status = ResponseStatus.Failed
                };
            }
        }

        public override async Task<ActivityResponse> EditActivity(Activity activity, ServerCallContext context)
        {
            try
            {
                var editedActivity = _activityManager.EditActivity(activity);

                return new ActivityResponse
                {
                    Message = $"Successfully updated activity: {editedActivity.Name}",
                    Status = ResponseStatus.Success
                };
            }
            catch (Exception ex)
            {
                return new ActivityResponse
                {
                    Message = $"Failed to update given activity: ActivityId = {activity.Id}, Error = {ex.Message}",
                    Status = ResponseStatus.Failed
                };
            }
        }
    }
}
