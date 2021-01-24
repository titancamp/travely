using Hangfire;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Travely.SchedulerManager.Abstraction.Job;

namespace Travely.SchedulerManager.Job
{
    class JobService : IJobService
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;
        public JobService(IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
        {
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
        }
        public Task Dequeue(string jobId) => Task.FromResult(_backgroundJobClient.Delete(jobId));
        public Task Enqueue(Expression<Action> methodCall) => Task.FromResult(_backgroundJobClient.Enqueue(methodCall));
        public Task EnqueueAfter(Expression<Action> methodCall, TimeSpan delay) => Task.FromResult(_backgroundJobClient.Schedule(methodCall, delay));
        public Task Recurrent(Expression<Action> methodCall, string cronExpression) => Task.Run(() => _recurringJobManager.AddOrUpdate("Run Recurring Job", methodCall, cronExpression));

    }
}