using System;
using System.Collections.Generic;
using Travely.SchedulerManager.Service;

namespace Travely.SchedulerManager
{
    public class BookingCancellationExpirationNotificationModel: INotificationModel
    {
        public long TourId { get; set; }

        public string TourName { get; set; }
        public string HotelName { get; set; }

        //TODO: calculate days
        public int NumberOfDaysUntilExpiration => BookingCancellationDate.Day;

        public DateTime BookingCancellationDate { get; set; }
        public IEnumerable<long> UserIds { get; set; }
    }
}