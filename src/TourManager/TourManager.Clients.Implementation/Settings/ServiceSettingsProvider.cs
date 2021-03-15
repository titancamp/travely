using Microsoft.Extensions.Options;
using TourManager.Clients.Abstraction.Settings;
using TourManager.Common.Settings;

namespace TourManager.Clients.Implementation.Settings
{
    public class ServiceSettingsProvider : IServiceSettingsProvider
    {
        private readonly IOptions<GrpcServiceSettings> _grpcServiceSettings;

        public ServiceSettingsProvider(IOptions<GrpcServiceSettings> grpcServiceSettings)
        {
            _grpcServiceSettings = grpcServiceSettings;
        }

        public string ComposeActivityServiceUrl()
        {
            return _grpcServiceSettings.Value.ActivityServiceUrl;
        }

        public string ComposePropertyServiceUrl()
        {
            return _grpcServiceSettings.Value.PropertyServiceUrl;
        }
    }
}
