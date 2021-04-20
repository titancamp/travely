using System;
using System.Collections.Generic;
using Travely.SchedulerManager.Service;

namespace Travely.SchedulerManager
{
    public class IncompleteBookingRequestsNotificationModel : INotificationModel
    {
        public long TourId { get; set; }
        public string TourName { get; set; }
        public DateTime TourStartDate { get; set; }
        public IEnumerable<long> UserIds { get; set; }
    }
}