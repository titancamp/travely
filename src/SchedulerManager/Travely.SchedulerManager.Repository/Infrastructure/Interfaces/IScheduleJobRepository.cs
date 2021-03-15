using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.SchedulerManager.Repository
{
    public interface IScheduleJobRepository
    {
        Task<IEnumerable<string>> GetJobIdsAsync(long scheduleInfoId);
    }
}
