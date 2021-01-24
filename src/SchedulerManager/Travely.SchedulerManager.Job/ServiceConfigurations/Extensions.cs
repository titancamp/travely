using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Travely.SchedulerManager.Abstraction.Job;

namespace Travely.SchedulerManager.Job
{
    public static class Extensions
    {

        public static IServiceCollection AddJobService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJobService, JobService>();
            services.AddHangfire(conf => conf
                   .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                   .UseSimpleAssemblyNameTypeSerializer()
                   .UseRecommendedSerializerSettings()
                   .UseSqlServerStorage(configuration["Hangfire:ConnectionString"], new SqlServerStorageOptions
                   {
                       CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                       SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                       QueuePollInterval = TimeSpan.Zero,
                       UseRecommendedIsolationLevel = true,
                       DisableGlobalLocks = true
                   }));
            services.AddHangfireServer();
            return services;
        }

        public static IApplicationBuilder UseJobClient(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard();
            app.UseEndpoints(endpoints => endpoints.MapHangfireDashboard());
            return app;
        }
    }
}
