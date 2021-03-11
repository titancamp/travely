using System.Threading.Tasks;

namespace Travely.SchedulerManager
{
    public interface IAsyncJob<TParameter> where TParameter : IParameter
    {
        Task ExecuteAsync(TParameter parameter);
    }
}
