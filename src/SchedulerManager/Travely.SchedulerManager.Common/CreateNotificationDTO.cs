using System;
using System.Collections.Generic;

namespace Travely.SchedulerManager
{
    public class CreateNotificationDTO
    {
        public long BookingId { get; set; }

        public string BookingName { get; set; }

        public BookingType BookingType { get; set; }

        public string Message { get; set; }

        public DateTime NotifyDate { get; set; }

        public IEnumerable<long> UserIds { get; set; }
    }
}
