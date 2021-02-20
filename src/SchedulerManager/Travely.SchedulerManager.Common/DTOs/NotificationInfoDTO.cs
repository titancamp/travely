using System;
using System.Collections.Generic;

namespace Travely.SchedulerManager.Common
{
    public class NotificationInfoDTO
    {
        public string Message { get; set; }

        public int Module { get; set; }

        public int RefId { get; set; }

        public IEnumerable<UserNotificationInfoDTO> NotificationInfos { get; set; }
    }
}
