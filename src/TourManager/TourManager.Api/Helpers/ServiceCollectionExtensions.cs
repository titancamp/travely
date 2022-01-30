using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Travely.ClientManager.Grpc.Mapper;

namespace TourManager.Api.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            var mappingProfiles = new[]
            {
                typeof(MappingConfig),
                typeof(ClientManagerClientProfile)
            };

            services.AddAutoMapper(mappingProfiles);

            return services;
        }
    }
}
