using System.Threading.Tasks;

namespace Travely.SchedulerManager
{
    public interface IRecurrentAsyncJobService<TParameter> : IAsyncEndJob where TParameter : IParameter
    {
        Task StartJobAsync(IAsyncJob<TParameter> job, string jobId, string cronExpression, TParameter parameter);
    }
}
