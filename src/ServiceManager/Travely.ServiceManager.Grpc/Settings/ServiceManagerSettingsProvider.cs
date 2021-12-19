using Microsoft.Extensions.Options;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;

namespace Travely.ServiceManager.Grpc.Settings
{
    public class ServiceManagerSettingsProvider : IServiceSettingsProvider<ActivityProto.ActivityProtoClient>
    {
        public ServiceManagerSettingsProvider(IOptions<GrpcSettings<ActivityProto.ActivityProtoClient>> settings)
        {
            Settings = settings.Value;
        }

        public GrpcSettings<ActivityProto.ActivityProtoClient> Settings { get; }
    }
}
