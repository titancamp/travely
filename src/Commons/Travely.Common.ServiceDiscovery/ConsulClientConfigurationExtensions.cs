using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Travely.Common.ServiceDiscovery
{
    public static class ConsulClientConfigurationExtensions
    {
        public static IServiceCollection AddConsul(
            this IServiceCollection services, 
            IConfiguration configuration, 
            IHostEnvironment environment)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var consulConfiguration = configuration.GetSection(nameof(ConsulClientConfiguration)).Get<ConsulClientConfiguration>();
            if (consulConfiguration?.Address != null)
            {
                services.AddConsulServices(configuration);
            }

            return services;
        }
    }
}
