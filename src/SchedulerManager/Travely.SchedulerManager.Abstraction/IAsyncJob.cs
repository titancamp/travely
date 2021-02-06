using System.Threading.Tasks;
using Travely.SchedulerManager.Service;

namespace Travely.SchedulerManager
{
    public interface IAsyncJob<TParameter> where TParameter : IParameter
    {
        Task ExecuteAsync(TParameter parameter);
    }
}
