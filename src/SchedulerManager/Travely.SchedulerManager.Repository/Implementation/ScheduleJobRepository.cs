using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Repository.Implementation
{
    public class ScheduleJobRepository : Repository<ScheduleJob>, IScheduleJobRepository
    {
        public ScheduleJobRepository(SchedulerDbContext context) : base(context) { }

        public async Task<IEnumerable<string>> GetJobIdsAsync(long scheduleInfoId)
        {
            var jobList = await GetListAsync(o => o.ScheduleInfoId == scheduleInfoId);
            return jobList.Select(o => o.JobId);
        }
    }
}
