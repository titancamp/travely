using Microsoft.Extensions.DependencyInjection;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Repository.Filters;
using Travely.SupplierManager.Service;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.Extensions.DependencyInjection
{
    public static class SupplierServiceCollectionExtensions
    {
        public static IServiceCollection AddSupplierServices(this IServiceCollection services)
        {
            services.AddSupplierRepositories();
            services.AddScoped<ISupplierService<Accommodation, AccommodationFilter>, SupplierService<Accommodation, AccommodationEntity, AccommodationFilter>>();
            services.AddScoped<ISupplierService<Activities, ActivitiesFilter>, SupplierService<Activities, ActivitiesEntity, ActivitiesFilter>>();
            services.AddScoped<ISupplierService<Food, FoodFilter>, SupplierService<Food, FoodEntity, FoodFilter>>();
            services.AddScoped<ISupplierService<Guides, GuidesFilter>, SupplierService<Guides, GuidesEntity, GuidesFilter>>();
            services.AddScoped<ISupplierService<Transportation, TransportationFilter>, SupplierService<Transportation, TransportationEntity, TransportationFilter>>();
            
            return services;
        }
    }
}