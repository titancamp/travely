namespace Travely.SchedulerManager.Grpc.Client.Models
{
    public class ReminderNotification
    {
        public int BookingId { get; set; }

        public string Message { get; set; }
    }
}
