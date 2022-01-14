using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Travely.SupplierManager.Repository;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Extensions.DependencyInjection
{
    public static class SupplierRepositoryCollectionExtensions
    {
        public static IServiceCollection AddSupplierRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISupplierRepository<AccommodationEntity>, SupplierRepository<AccommodationEntity>>();
            services.AddScoped<ISupplierRepository<ActivitiesEntity>, SupplierRepository<ActivitiesEntity>>();
            services.AddScoped<ISupplierRepository<FoodEntity>, SupplierRepository<FoodEntity>>();
            services.AddScoped<ISupplierRepository<GuidesEntity>, SupplierRepository<GuidesEntity>>();
            services.AddScoped<ISupplierRepository<TransportationEntity>, SupplierRepository<TransportationEntity>>();
            return services;
        }
    }
}