using System;
using System.Threading.Tasks;

namespace Travely.SchedulerManager
{
    public interface IScheduledAsyncJobService<TParameter> : IAsyncEndJob where TParameter : IParameter
    {
        Task<string> StartJobAsync(IAsyncJob<TParameter> job, TimeSpan delay, TParameter parameter);
    }
}
