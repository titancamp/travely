using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Travely.Common.ServiceDiscovery
{
    public static class ServiceDiscoveryExtensions
    {
        public static void RegisterConsulServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConsulClientConfiguration>(configuration.GetSection(nameof(ConsulClientConfiguration)));
            services.Configure<ServiceDiscoveryConfiguration>(configuration.GetSection(nameof(ServiceDiscoveryConfiguration)));
            services.AddSingleton<IHostedService, ServiceDiscoveryHostedService>();
            services.AddSingleton<IConsulClient, TravelyConsulClient>();
        }
    }
}
