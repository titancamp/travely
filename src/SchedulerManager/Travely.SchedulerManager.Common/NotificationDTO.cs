using System;

namespace Travely.SchedulerManager
{
    public class NotificationDTO
    {
        public long BookingId { get; set; }

        public string Message { get; set; }

        public DateTime NotifyDate { get; set; }
    }
}
