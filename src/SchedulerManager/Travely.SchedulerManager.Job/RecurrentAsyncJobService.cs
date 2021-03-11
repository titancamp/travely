using Hangfire;
using System.Threading.Tasks;

namespace Travely.SchedulerManager.Job
{
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
