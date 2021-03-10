using System.Threading.Tasks;

namespace Travely.SchedulerManager
{
    public interface IAsyncEndJob
    {
        Task EndJobAsync(string jobId);
    }
}
