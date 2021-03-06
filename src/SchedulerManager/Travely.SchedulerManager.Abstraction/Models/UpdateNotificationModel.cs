using System;
using System.Collections.Generic;
using Travely.SchedulerManager.Common.Enums;
using Travely.SchedulerManager.Service;

namespace Travely.SchedulerManager
{
    public class UpdateNotificationModel : INotificationModel
    {
        public long RecurseId { get; set; }
        public TravelyModule Module { get; set; }
        public MessageTemplate MessageTemplate { get; set; }
        public string JsonData { get; set; }
        public IEnumerable<long> UserIds { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
