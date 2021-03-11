using System;
using System.Collections.Generic;
using Travely.SchedulerManager.Common.Enums;

namespace Travely.SchedulerManager
{
    public class CreateNotificationModel
    {
        public long RecurseId { get; set; }
        public TravelyModule Module { get; set; }
        public string JsonData { get; set; }

        public DateTime ExpirationDate { get; set; }

        public MessageTemplate MessageTemplate { get; set; }
        public IEnumerable<long> UserIds { get; set; }
    }
}