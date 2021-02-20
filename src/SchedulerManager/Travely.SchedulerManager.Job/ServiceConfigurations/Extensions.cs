using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using Travely.SchedulerManager.Common;

namespace Travely.SchedulerManager.Job
{
    public static class Extensions
    {
        public static IServiceCollection AddJobService(this IServiceCollection services)
        {
            var options = services.BuildServiceProvider().GetService<IOptionsMonitor<JobOptions>>().CurrentValue;
            services.AddSingleton(typeof(IEnqueueAsyncJobService<>), typeof(EnqueueAsyncJobService<>));
            services.AddSingleton(typeof(IScheduledAsyncJobService<>), typeof(ScheduledAsyncJobService<>));
            services.AddSingleton(typeof(IRecurrentAsyncJobService<>), typeof(RecurrentAsyncJobService<>));

            services.AddHangfire(conf => conf
                   .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                   .UseSimpleAssemblyNameTypeSerializer()
                   .UseRecommendedSerializerSettings()
                   .UseSqlServerStorage(options.ConnectionString, new SqlServerStorageOptions
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
