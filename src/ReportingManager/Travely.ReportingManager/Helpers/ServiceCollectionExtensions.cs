using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TourManager.Clients.Implementation.Mappers;
using Travely.Common.Grpc.Abstraction;
using Travely.ReportingManager.Data;
using Travely.ReportingManager.Grpc.Client.Abstraction;
using Travely.ReportingManager.Grpc.Client.Implementation;
using Travely.ReportingManager.Grpc.Settings;
using Travely.ReportingManager.Profiles;
using Travely.ReportingManager.Protos;
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
                 typeof(ReporingClientProfile),
                 typeof(CommonProfile),
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
            services.AddScoped<IReportingManagerClient, ReportingManagerClient>();
            services.AddScoped<IServiceSettingsProvider<ToDoItemProtoService.ToDoItemProtoServiceClient>, ReportingManagerSettingsProvider>();
            services.AddScoped<IToDoItemService, ToDoItemService>();
            return services;
        }
    }
}
