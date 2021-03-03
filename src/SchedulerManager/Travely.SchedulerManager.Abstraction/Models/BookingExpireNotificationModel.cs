using System;
using System.Collections.Generic;
using Travely.SchedulerManager.Service;

namespace Travely.SchedulerManager
{
    public class BookingExpireNotificationModel: INotificationModel
    {
        public long TourId { get; set; }

        public string TourName { get; set; }
        public string BookingName { get; set; }

        public DateTime ExpireDate { get; set; }
        public IEnumerable<long> UserIds { get; set; }
    }
}