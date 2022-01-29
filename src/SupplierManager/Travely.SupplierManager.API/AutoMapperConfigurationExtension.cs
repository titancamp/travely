using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Travely.SupplierManager.API.Mappers;

namespace Travely.SupplierManager.Extensions.DependencyInjection
{
    public static class AutoMapperConfigurationExtension
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(provider => new MapperConfiguration(cfg => 
            {
                cfg.AddProfile(new AccommodationProfile());
                cfg.AddProfile(new ActivitiesProfile());
                cfg.AddProfile(new CommonProfile());
                cfg.AddProfile(new FoodProfile());
                cfg.AddProfile(new GuidesProfile());
                cfg.AddProfile(new TransportationProfile());
            }).CreateMapper());
        }
    }
}