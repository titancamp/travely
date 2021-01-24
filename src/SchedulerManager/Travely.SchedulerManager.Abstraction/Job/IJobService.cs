using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Travely.SchedulerManager.Abstraction.Job
{
    public interface IJobService
    {
        Task Enqueue(Expression<Action> methodCall);
        Task Dequeue(string jobId);
        Task EnqueueAfter(Expression<Action> methodCall, TimeSpan delay);
        Task Recurrent(Expression<Action> methodCall, string cronExpression);
    }
}
