﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Travely.SchedulerManager.Common;
using Travely.SchedulerManager.Repository.Implementation;
using Travely.SchedulerManager.Repository.Infrastructure.Interfaces;

namespace Travely.SchedulerManager.Repository
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services, RepositoryOptions options)
        {
            services.AddDContext(options.ConnectionString);
            services.AddRepositories();
            services.AddDbSeeding();
            return services;
        }

        public static async Task<IHost> SeedData(this IHost host, bool isDevelopmentEnvironment = true)
        {
            using var scope = host.Services.CreateScope();
            var scopeFactory = scope.ServiceProvider.GetRequiredService<IServiceScopeFactory>();
            var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
            dbInitializer.Initialize(scope);
            await dbInitializer.SeedData(isDevelopmentEnvironment);
            return host;
        }

        private static void AddDContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SchedulerDbContext>(
                options => options.UseSqlServer(connectionString));

        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IScheduleInfoRepository, ScheduleInfoRepository>();
            services.AddScoped<IScheduleMessageTemplateRepository, ScheduleMessageTemplateRepository>();
            services.AddScoped<IScheduleJobRepository, ScheduleJobRepository>();
        }

        private static void AddDbSeeding(this IServiceCollection service)
        {
            service.AddScoped<IDbInitializer, DbInitializer>();
        }
    }
}