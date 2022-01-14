using Microsoft.Extensions.DependencyInjection;
using Travely.SupplierManager.Grpc.Client.Abstraction;
using Travely.SupplierManager.Grpc.Client.Implementation;
using Travely.SupplierManager.Repository;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service;
using Travely.SupplierManager.Service.Helpers;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.Extensions.DependencyInjection
{
    public static class SupplierServiceCollectionExtensions
    {
        public static IServiceCollection AddSupplierServices(this IServiceCollection services)
        {
            services.AddSupplierRepositories();
            services.AddScoped<ISupplierService<Accommodation>, SupplierService<Accommodation, AccommodationEntity>>();
            // services.AddSingleton<ISearchHelper<AccommodationEntity>, AccommodationSearchHelper>();
            // services.AddSingleton<ISortHelper<AccommodationEntity>, SortHelper<AccommodationEntity>>();
            
            services.AddScoped<ISupplierService<Activities>, SupplierService<Activities, ActivitiesEntity>>();
            services.AddScoped<ISupplierService<Food>, SupplierService<Food, FoodEntity>>();
            services.AddScoped<ISupplierService<Guides>, SupplierService<Guides, GuidesEntity>>();
            services.AddScoped<ISupplierService<Transportation>, SupplierService<Transportation, TransportationEntity>>();
            
            services.AddScoped<ISupplierManagerClient, SupplierManagerClient>();
            
            return services;
        }
    }
}