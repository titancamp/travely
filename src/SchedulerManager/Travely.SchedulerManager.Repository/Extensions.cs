using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Travely.SchedulerManager.Common;
using Travely.SchedulerManager.Repository.Implementation;
using Travely.SchedulerManager.Repository.Infrastructure.Interfaces;

namespace Travely.SchedulerManager.Repository
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection(RepositoryOptions.Section).Get<RepositoryOptions>();
            services.AddDContext(options.ConnectionString);
            services.AddRepositories();
            services.AddDbSeeding();
            return services;
        }

        public static void ConfigureRepositoryLayer(this IApplicationBuilder app, bool isDevelopmentEnvironment)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
            dbInitializer.Initialize();
            //TODO: Find a better solution instead of wait!
            dbInitializer.SeedData(isDevelopmentEnvironment).Wait();
        }

        private static void AddDContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SchedulerDbContext>(
                options => options.UseSqlServer(connectionString));

        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IScheduleInfoRepository, ScheduleInfoRepository>();
            services.AddTransient<IScheduleMessageTemplateRepository, ScheduleMessageTemplateRepository>();
        }

        private static void AddDbSeeding(this IServiceCollection service)
        {
            service.AddTransient<IDbInitializer, DbInitializer>();
        }
    }
}
