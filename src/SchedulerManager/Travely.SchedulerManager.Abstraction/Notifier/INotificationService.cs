using System.Threading.Tasks;

namespace Travely.SchedulerManager
{
    public interface INotificationService
    {
        Task Notify(string userId);
        Task SendEmail(string receiverEmail, string title, string subject, string content);
    }
}
