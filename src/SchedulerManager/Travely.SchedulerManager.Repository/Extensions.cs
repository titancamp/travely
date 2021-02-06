using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Travely.SchedulerManager.Repository.Implementation;
using Travely.SchedulerManager.Repository.Interfaces;

namespace Travely.SchedulerManager.Repository
{
    public static class Extensions
    {
        public static IServiceCollection AddDb(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SchedulerDbContext>(
                options => options.UseSqlServer(connectionString));

            services.RegisterDataLayerServices();
            return services;
        }

        private static void RegisterDataLayerServices(this IServiceCollection services)
        {
            services.AddTransient<IScheduleInfoRepository, ScheduleInfoRepository>();
        }
    }
}
