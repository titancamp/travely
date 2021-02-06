using Hangfire;
using System;
using System.Threading.Tasks;
using Travely.SchedulerManager.Service;

namespace Travely.SchedulerManager.Job
{
    public interface IScheduledAsyncJobService<TParameter> : IAsyncEndJob where TParameter : IParameter
    {
        Task<string> StartJobAsync(IAsyncJob<TParameter> job, TimeSpan delay, TParameter parameter);
    }
    public class ScheduledAsyncJobService<TParameter> : IScheduledAsyncJobService<TParameter>
       where TParameter : IParameter
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        public ScheduledAsyncJobService(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }

        public Task EndJobAsync(string jobId) => Task.FromResult(_backgroundJobClient.Delete(jobId));

        public Task<string> StartJobAsync(IAsyncJob<TParameter> job, TimeSpan delay, TParameter parameter)
        {
            return Task.FromResult(_backgroundJobClient.Schedule(() => job.ExecuteAsync(parameter), delay));
        }
    }
}
