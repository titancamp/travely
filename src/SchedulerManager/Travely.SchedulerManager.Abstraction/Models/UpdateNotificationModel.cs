using System;
using System.Collections.Generic;

namespace Travely.SchedulerManager
{
    public class UpdateNotificationModel
    {
        public long TourId { get; set; }

        public long BookingId { get; set; }

        public string TourName { get; set; }

        public string BookingName { get; set; }

        public string BookingNotes { get; set; }

        public DateTime ExpireDate { get; set; }

        public IEnumerable<long> UserIds { get; set; }
    }
}
