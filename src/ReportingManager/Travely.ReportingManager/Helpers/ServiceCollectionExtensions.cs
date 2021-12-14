using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Travely.ReportingManager.Data;
using Travely.ReportingManager.Services.Abstractions;
using Travely.ReportingManager.Services.Implementations;

namespace Travely.ReportingManager.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            var mappingProfiles = new[]
            {
                 typeof(Profiles.ToDoMappingProfile),
                 typeof(Services.MappingProfiles.ToDoMappingProfile),
            };

            services.AddAutoMapper(mappingProfiles);

            return services;
        }

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ToDoDbContext>(options =>
                 options.UseSqlServer(connectionString, x => x.MigrationsAssembly(typeof(ToDoDbContext).Assembly.GetName().Name)));

            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IToDoItemService, ToDoItemService>();
            return services;
        }
    }
}
