using Consul;
using Microsoft.Extensions.Options;

namespace Travely.Common.ServiceDiscovery
{
    public class TravelyConsulClient : ConsulClient
    {
        public TravelyConsulClient(IOptions<ConsulClientConfiguration> config)
        {
            if (config.Value.Address != default)
            {
                Config.Address = config.Value.Address;
            }
        }
    }
}
