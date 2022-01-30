using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Travely.ClientManager.Grpc.Mapper;
using Travely.ClientManager.Repository;
using Travely.ClientManager.Service.Mappers;

namespace Travely.ClientManager.Service.Extensions.ServiceCollectionExtensions
{
    public static class ServiceConfigurationExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TouristContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("TouristDB")));
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mappingProfiles = new[]
            {
                typeof(ClientProfile),
                typeof(PreferenceProfile),
                typeof(ClientManagerClientProfile)
            };

            services.AddAutoMapper(mappingProfiles);
        }
    }
}
