using System;
using System.Threading.Tasks;

namespace Travely.SchedulerManager.Service
{
    public class BookingNotificationJobManager : IAsyncJob<BookingNotificationParameter>
    {
        private readonly INotificationService _notificationService;

        public BookingNotificationJobManager(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public Task ExecuteAsync(BookingNotificationParameter parameter)
        {
            //TODO
            return Task.CompletedTask;
        }
    }
}
