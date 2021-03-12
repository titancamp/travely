using Travely.SchedulerManager.Repository.Entities;
using Travely.SchedulerManager.Repository.Infrastructure.Interfaces;

namespace Travely.SchedulerManager.Repository.Implementation
{
    public class ScheduleInfoRepository : Repository<ScheduleInfo>, IScheduleInfoRepository
    {
        public ScheduleInfoRepository(SchedulerDbContext context): base(context)
        {
        }
    }
}
