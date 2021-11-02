using Grpc.Net.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourManager.Clients.Abstraction.ServiceManager;
using TourManager.Clients.Abstraction.Settings;
using Travely.ServiceManager.Service;
using Activity = TourManager.Common.Clients.Activity;
using ActivityType = TourManager.Common.Clients.ActivityType;
using ActivityModel = Travely.ServiceManager.Service.Activity;
using ActivityResponse = TourManager.Common.Clients.ActivityResponse;
using TourManager.Clients.Implementation.Mappers;

namespace TourManager.Clients.Implementation.ServiceManager
{
    public class ServiceManagerClient : IServiceManagerClient
    {
        private readonly IServiceSettingsProvider _serviceSettingsProvider;

        public ServiceManagerClient(IServiceSettingsProvider serviceSettingsProvider)
        {
            _serviceSettingsProvider = serviceSettingsProvider;
        }

        public async Task<ActivityResponse> CreateActivityAsync(Activity activity)
        {
            var activityClient = GetActivityClient();

            var activityProtoModel = Mapping.Mapper.Map<ActivityModel>(activity);

            var response = await activityClient.CreateActivityAsync(activityProtoModel);

            return Mapping.Mapper.Map<ActivityResponse>(response);
        }

        public async Task<ActivityResponse> EditActivityAsync(Activity activity)
        {
            var activityClient = GetActivityClient();

            var activityProtoModel = Mapping.Mapper.Map<ActivityModel>(activity);

            var response = await activityClient.EditActivityAsync(activityProtoModel);

            return Mapping.Mapper.Map<ActivityResponse>(response);
        }

        public async Task<ActivityResponse> DeleteActivityAsync(long ActivityId)
        {
            var activityClient = GetActivityClient();

            var response = await activityClient.DeleteActivityAsync(new DeleteActivityRequest()
                                                                    {
                                                                        ActivityId = ActivityId
                                                                    });

            return Mapping.Mapper.Map<ActivityResponse>(response); 
        }

        public async Task<IEnumerable<Activity>> GetActivitiesAsync(long AgencyId)
        {
            var activityClient = GetActivityClient();

            var activities = await activityClient.GetActivitiesAsync(new GetActivitiesRequest()
                                                                    {
                                                                        AgencyId = AgencyId
                                                                    });

            return activities.Activities_.Select(s => Mapping.Mapper.Map<Activity>(s));
        }

        public async Task<IEnumerable<ActivityType>> SearchActivityTypesAsync(long agencyId, string activityTypeName)
        {
            var activityClient = GetActivityClient();

            var activityTypes = await activityClient.SearchActivityTypesAsync(new SearchActivityTypesRequest()
            {
                AgencyId = agencyId,
                ActivityTypeName = activityTypeName
            });

            return activityTypes.ActivityTypes_.Select(s => Mapping.Mapper.Map<ActivityType>(s));
        }

        public async Task<ActivityType> CreateActivityType(long agencyId, string activityTypeName)
        {
            var activityClient = GetActivityClient();
            return Mapping.Mapper.Map<ActivityType>(await activityClient.CreateActivityTypeAsync(new Travely.ServiceManager.Service.ActivityType()
            {
                ActivityName = activityTypeName,
                AgencyId = agencyId
            }));
        }

        private ActivityProto.ActivityProtoClient GetActivityClient() {
            var channel = GrpcChannel.ForAddress(_serviceSettingsProvider.ComposeActivityServiceUrl());

            return new ActivityProto.ActivityProtoClient(channel);
        }
    }
}
