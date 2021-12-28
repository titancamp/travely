using Microsoft.Extensions.Options;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;

namespace Travely.ClientManager.Grpc.Settings
{
    public class ClientManagerSettingsProvider : IServiceSettingsProvider<ClientProtoService.ClientProtoServiceClient>
    {
        public ClientManagerSettingsProvider(IOptions<GrpcSettings<ClientProtoService.ClientProtoServiceClient>> settings)
        {
            Settings = settings.Value;
        }

        public GrpcSettings<ClientProtoService.ClientProtoServiceClient> Settings { get; }
    }
}
