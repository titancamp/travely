using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace TourManager.Api.Bootstrapper
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingConfig());
            });

            services.AddSingleton(mapperConfig.CreateMapper());

            return services;
        }
    }
}