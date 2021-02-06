﻿using Hangfire;
using System.Threading.Tasks;
using Travely.SchedulerManager.Service;

namespace Travely.SchedulerManager.Job
{
    public interface IEnqueueAsyncJobService<TParameter> : IAsyncEndJob where TParameter : IParameter
    {
        Task<string> StartJobAsync(IAsyncJob<TParameter> job, TParameter parameter);
    }
    public class EnqueueAsyncJobService<TParameter> : IEnqueueAsyncJobService<TParameter> 
        where TParameter : IParameter
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        public EnqueueAsyncJobService(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }
        
        public Task EndJobAsync(string jobId) => Task.FromResult(_backgroundJobClient.Delete(jobId));

        public Task<string> StartJobAsync(IAsyncJob<TParameter> job, TParameter parameter)
        {
            return Task.FromResult(_backgroundJobClient.Enqueue(() => job.ExecuteAsync(parameter)));
        }
    }   
}
