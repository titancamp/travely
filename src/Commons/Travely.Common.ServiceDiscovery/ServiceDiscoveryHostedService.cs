using System.Threading;
using System.Threading.Tasks;
using Consul;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Travely.Common.ServiceDiscovery
{
    public class ServiceDiscoveryHostedService : IHostedService
    {
        private readonly IConsulClient _client;
        private readonly ServiceDiscoveryConfiguration _config;
        private string _registrationId;

        public ServiceDiscoveryHostedService(IConsulClient client, IOptions<ServiceDiscoveryConfiguration> options)
        {
            _client = client;
            _config = options.Value;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _registrationId = $"{_config.ServiceName}-{_config.ServiceId}";

            var registration = new AgentServiceRegistration
            {
                ID = _registrationId,
                Name = _config.ServiceName,
                Address = _config.ServiceAddress.Host,
                Port = _config.ServiceAddress.Port
            };

            _ = await _client.Agent.ServiceDeregister(registration.ID, cancellationToken);
            _ = await _client.Agent.ServiceRegister(registration, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _client.Agent.ServiceDeregister(_registrationId, cancellationToken);
        }
    }
}
