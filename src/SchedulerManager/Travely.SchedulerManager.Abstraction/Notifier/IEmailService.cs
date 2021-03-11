using System.Threading.Tasks;

namespace Travely.SchedulerManager.Notifier
{
    public interface IEmailService
    {
        Task SendEmailAsync(string receiverEmail, string title, string subject, string content);
    }
}
