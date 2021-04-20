using System;
using System.Collections.Generic;

namespace TourManager.Service.Model.SchedulerManager.Reminders
{
    public class CreateUpdateReminderRequest
    {
        public long TourId { get; set; }

        public long BookingId { get; set; }

        public string TourName { get; set; }

        public string BookingName { get; set; }

        public string BookingNotes { get; set; }

        public DateTime ExpireDate { get; set; }

        public IEnumerable<long> AssignedUserIds { get; set; }
    }
}
