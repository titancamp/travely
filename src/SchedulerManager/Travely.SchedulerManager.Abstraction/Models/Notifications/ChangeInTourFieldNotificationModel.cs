using System;
using System.Collections.Generic;
using Travely.SchedulerManager.Service;

namespace Travely.SchedulerManager
{
    public class ChangeInTourFieldNotificationModel : INotificationModel
    {
        public long TourId { get; set; }
        public string TourName { get; set; }
        public string ChangedFieldName { get; set; }
        public string UserWhoMadeTheChange { get; set; }
        public IEnumerable<long> UserIds { get; set; }
    }
}