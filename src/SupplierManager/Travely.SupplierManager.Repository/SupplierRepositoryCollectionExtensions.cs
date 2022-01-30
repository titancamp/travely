using Microsoft.Extensions.DependencyInjection;
using Travely.SupplierManager.Repository;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Extensions.DependencyInjection
{
    public static class SupplierRepositoryCollectionExtensions
    {
        public static IServiceCollection AddSupplierRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISupplierRepository<AccommodationEntity>, AccommodationRepository>();
            services.AddScoped<ISupplierRepository<ActivitiesEntity>, ActivitiesRepository>();
            services.AddScoped<ISupplierRepository<FoodEntity>, FoodRepository>();
            services.AddScoped<ISupplierRepository<GuidesEntity>, GuidesRepository>();
            services.AddScoped<ISupplierRepository<TransportationEntity>, TransportationRepository>();
            return services;
        }
    }
}