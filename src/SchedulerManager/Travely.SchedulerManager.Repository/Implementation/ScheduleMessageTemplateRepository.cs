using Travely.SchedulerManager.Repository.Entities;
using Travely.SchedulerManager.Repository.Infrastructure.Interfaces;

namespace Travely.SchedulerManager.Repository.Implementation
{
    public class ScheduleMessageTemplateRepository : Repository<ScheduleMessageTemplate>, IScheduleMessageTemplateRepository
    {
        public ScheduleMessageTemplateRepository(SchedulerDbContext context): base(context)
        {
        }
    }
}
