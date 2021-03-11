using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Travely.PropertyManager.Data.EntityFramework;
using Travely.PropertyManager.Service.Contracts;
using Travely.PropertyManager.Service.Services;

namespace Travely.PropertyManager.Bootstrapper.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            var mappingProfiles = new[]
            {
                typeof(Travely.PropertyManager.API.MappingProfiles.PropertyMappingProfile),
                typeof(Travely.PropertyManager.Service.MappingProfiles.PropertyMappingProfile)
            };

            services.AddAutoMapper(mappingProfiles);

            return services;
        }

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PropertyDbContext>(options =>
                 options.UseSqlServer(connectionString, x => x.MigrationsAssembly(typeof(PropertyDbContext).Assembly.GetName().Name)));

            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IPropertyService, PropertyService>();
            return services;
        }
    }
}
