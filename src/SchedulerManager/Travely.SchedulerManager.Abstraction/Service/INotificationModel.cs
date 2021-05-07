using System;
using System.Collections.Generic;

namespace Travely.SchedulerManager.Service
{
    public interface INotificationModel
    {
        public IEnumerable<long> UserIds { get; set; }
    }
}
