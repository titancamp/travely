using System.Threading.Tasks;

namespace Travely.SchedulerManager
{
    public interface IEnqueueAsyncJobService<TParameter> : IAsyncEndJob where TParameter : IParameter
    {
        Task<string> StartJobAsync(IAsyncJob<TParameter> job, TParameter parameter);
    }
}
