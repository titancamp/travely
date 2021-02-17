using System.Collections.Generic;

namespace Travely.SchedulerManager.Service
{
    public class BookingNotificationParameter : IParameter
    {
        public IEnumerable<long> UserScheduleIds { get; set; }
    }
}