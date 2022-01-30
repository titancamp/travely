using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;
using Travely.ServiceManager.Grpc.Client.Abstarction;

namespace Travely.ServiceManager.Grpc.Client.Implementation
{
    public class ServiceManagerClient : GrpcClientBase<ActivityProto.ActivityProtoClient>, IServiceManagerClient
    {
        public ServiceManagerClient(IServiceSettingsProvider<ActivityProto.ActivityProtoClient> serviceSettingsProvider)
            : base(serviceSettingsProvider)
        {
        }

        public Task<ActivityResponse> CreateActivityAsync(Activity activity)
        {
            return HandleAsync(async (client) =>
            {
                var response = await client.CreateActivityAsync(activity);
                return response;
            });
        }

        public Task<ActivityResponse> EditActivityAsync(Activity activity)
        {
            return HandleAsync(async (client) =>
            {
                var response = await client.EditActivityAsync(activity);

                return response;
            });
        }

        public Task<ActivityResponse> DeleteActivityAsync(long ActivityId)
        {
            return HandleAsync(async (client) =>
            {
                var response = await client.DeleteActivityAsync(new DeleteActivityRequest()
                {
                    ActivityId = ActivityId
                });
                return response;
            });
        }

        public Task<IEnumerable<Activity>> GetActivitiesAsync(long AgencyId)
        {
            return HandleAsync(async (client) =>
            {
                var activities = await client.GetActivitiesAsync(new GetActivitiesRequest()
                {
                    AgencyId = AgencyId
                });

                return activities.Activities_.Select(s => s);
            });
        }

        public Task<IEnumerable<ActivityType>> SearchActivityTypesAsync(long agencyId, string activityTypeName)
        {
            return HandleAsync(async (client) =>
            {
                var activityTypes = await client.SearchActivityTypesAsync(new SearchActivityTypesRequest()
                {
                    AgencyId = agencyId,
                    ActivityTypeName = activityTypeName
                });

                return activityTypes.ActivityTypes_.Select(s => s);
            });
        }

        public Task<ActivityType> CreateActivityType(long agencyId, string activityTypeName)
        {
            return HandleAsync(async (client) =>
            {
                return await client.CreateActivityTypeAsync(new ActivityType()
                {
                    ActivityName = activityTypeName,
                    AgencyId = agencyId
                });
            });
        }
    }
}
