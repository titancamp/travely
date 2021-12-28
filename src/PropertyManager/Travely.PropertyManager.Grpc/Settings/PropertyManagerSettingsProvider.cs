using Grpc.Net.Client;
using Microsoft.Extensions.Options;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;

namespace Travely.PropertyManager.Grpc.Settings
{
    public class PropertyManagerSettingsProvider : IServiceSettingsProvider<Property.PropertyClient>
    {

        public PropertyManagerSettingsProvider(IOptions<GrpcSettings<Property.PropertyClient>> settings)
        {
            Settings = settings.Value;
        }

        public GrpcSettings<Property.PropertyClient> Settings { get; }
    }
}
