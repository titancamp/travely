using System.Threading.Tasks;

namespace Travely.SchedulerManager.Abstraction.Notifier
{
    public interface INotifierService
    {
        Task Notify(string userId);
    }
}
