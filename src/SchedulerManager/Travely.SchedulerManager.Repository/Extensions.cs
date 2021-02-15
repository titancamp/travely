using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Travely.SchedulerManager.Repository.Implementation;
using Travely.SchedulerManager.Repository.Infrastructure.Interfaces;

namespace Travely.SchedulerManager.Repository
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDContext(connectionString);
            services.AddRepositories();
            return services;
        }

        private static void AddDContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SchedulerDbContext>(
                options => options.UseSqlServer(connectionString));

        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IScheduleInfoRepository, ScheduleInfoRepository>();
        }
    }
}
