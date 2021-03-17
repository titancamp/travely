using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travely.SchedulerManager.Common;
using Travely.SchedulerManager.Job;
using Travely.SchedulerManager.Notifier.Helpers;
using Travely.SchedulerManager.Repository;

namespace Travely.SchedulerManager.API.Helpers
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection AddJobService(this IServiceCollection services, IConfiguration configuration)
        {
            var jobOptions = configuration.GetSection(JobOptions.Section).Get<JobOptions>();
            return services.AddJobService(jobOptions);
        }

        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var repositoryOptions = configuration.GetSection(RepositoryOptions.Section).Get<RepositoryOptions>();
            return services.AddRepositoryLayer(repositoryOptions);
        }

        public static IServiceCollection AddNotifier(this IServiceCollection services, IConfiguration configuration)
        {
            var notifierOptions = configuration.GetSection(NotifierOptions.Section).Get<NotifierOptions>();
            return services.AddNotifier(notifierOptions);
        }
    }
}
