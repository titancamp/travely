using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Travely.SchedulerManager.Repository.Infrastructure.Interfaces;
using Travely.SchedulerManager.Repository.Infrastructure.Seeding;

namespace Travely.SchedulerManager.Repository.Implementation
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IScheduleMessageTemplateRepository _scheduleMessageTemplateRepository;

        public DbInitializer(IScheduleMessageTemplateRepository scheduleMessageTemplateRepository)
        {
            _scheduleMessageTemplateRepository = scheduleMessageTemplateRepository;
        }

        public void Initialize(IServiceScope scope)
        {
            using var context = scope.ServiceProvider.GetService<SchedulerDbContext>();
            context.Database.Migrate();
        }

        public async Task SeedData(bool isDevelopmentEnvironment)
        {
            if (isDevelopmentEnvironment)
            {
                await DbSeeding.ScheduleMessageTemplateSeeding(_scheduleMessageTemplateRepository);
            }
        }
    }
}
