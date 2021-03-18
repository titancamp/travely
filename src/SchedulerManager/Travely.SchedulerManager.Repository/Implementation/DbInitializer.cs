using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Travely.SchedulerManager.Repository.Infrastructure.Interfaces;
using Travely.SchedulerManager.Repository.Infrastructure.Seeding;

namespace Travely.SchedulerManager.Repository.Implementation
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IScheduleMessageTemplateRepository _scheduleMessageTemplateRepository;

        public DbInitializer(IServiceScopeFactory scopeFactory, IScheduleMessageTemplateRepository scheduleMessageTemplateRepository)
        {
            _scopeFactory = scopeFactory;
            _scheduleMessageTemplateRepository = scheduleMessageTemplateRepository;
        }

        public void Initialize()
        {
            using var serviceScope = _scopeFactory.CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<SchedulerDbContext>();
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