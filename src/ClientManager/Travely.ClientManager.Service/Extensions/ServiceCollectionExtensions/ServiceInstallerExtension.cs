using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.ClientManager.Abstraction.Abstraction.Repository;
using Travely.ClientManager.Repository.Repository;

namespace Travely.ClientManager.Service.Extensions.ServiceCollectionExtensions
{
    public static class ServiceInstallerExtension
    {
        public static void InstallRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<ITouristRepository, TouristRepository>();
            services.AddScoped<IPreferenceRepository, PreferenceRepository>();
        }
    }
}
