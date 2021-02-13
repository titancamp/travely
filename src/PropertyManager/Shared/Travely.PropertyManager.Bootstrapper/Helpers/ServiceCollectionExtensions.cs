﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Travely.PropertyManager.Bootstrapper.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PropertyMappingProfile));
            return services;
        }

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PropertyDbContext>(options =>
                 options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Travely.PropertyManager.Data")));

            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IPropertyService, PropertyService>();
            return services;
        }
    }
}
