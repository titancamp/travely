using System;
using System.Collections.Generic;
using Travely.SchedulerManager.Service;

namespace Travely.SchedulerManager
{
    public class BookingCancellationExpirationNotificationModel: INotificationModel
    {
        public long TourId { get; set; }
        public long BookingId { get; set; }
        public string TourName { get; set; }
        public string BookingName { get; set; }

        //TODO: calculate days
        public int NumberOfDaysUntilExpiration => BookingCancellationDate.Day;

        public DateTime BookingCancellationDate { get; set; }
        public IEnumerable<long> UserIds { get; set; }
    }
}