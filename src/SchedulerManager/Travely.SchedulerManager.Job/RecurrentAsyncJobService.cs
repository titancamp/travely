using Hangfire;
using System.Threading.Tasks;
using Travely.SchedulerManager.Service;

namespace Travely.SchedulerManager.Job
{
    public interface IRecurrentAsyncJobService<TParameter> : IAsyncEndJob where TParameter : IParameter
    {
        Task StartJobAsync(IAsyncJob<TParameter> job, string jobId, string cronExpression, TParameter parameter);
    }

    public class RecurrentAsyncJobService<TParameter> : IRecurrentAsyncJobService<TParameter> where TParameter : IParameter
    {
        private readonly IRecurringJobManager _recurringJobClient;

        public RecurrentAsyncJobService(IRecurringJobManager recurringJobClient)
        {
            _recurringJobClient = recurringJobClient;
        }

        public Task EndJobAsync(string jobId)
        {
            _recurringJobClient.RemoveIfExists(jobId);
            return Task.CompletedTask;
        }

        public Task StartJobAsync(IAsyncJob<TParameter> job, string jobId, string cronExpression, TParameter parameter)
        {
            _recurringJobClient.AddOrUpdate(jobId, () => job.ExecuteAsync(parameter), cronExpression);
            return Task.CompletedTask;
        }
    }
}
