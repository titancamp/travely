using System.Threading.Tasks;

namespace Travely.SchedulerManager.Job
{
    public interface IAsyncEndJob 
    {
        Task EndJobAsync(string jobId);
    }
}
