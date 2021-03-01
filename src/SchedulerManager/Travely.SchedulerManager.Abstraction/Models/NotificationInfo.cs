using System;
using System.Collections.Generic;

namespace Travely.SchedulerManager
{
    public class NotificationInfo
    {
        public string Message { get; set; }

        public int Module { get; set; }

        public int RefId { get; set; }

        public IEnumerable<UserNotificationInfo> NotificationInfos { get; set; }
    }
}
