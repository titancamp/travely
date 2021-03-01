using System;
using System.Collections.Generic;

namespace Travely.SchedulerManager
{
    public class BookingExpireNotification
    {
        public long TourId { get; set; }

        public string TourName { get; set; }
        public string BookingName { get; set; }

        public DateTime ExpireDate { get; set; }
        public IEnumerable<long> UserIds { get; set; }
    }
}