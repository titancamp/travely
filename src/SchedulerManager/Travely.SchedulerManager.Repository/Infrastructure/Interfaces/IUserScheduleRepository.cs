using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.SchedulerManager.Common.Enums;

namespace Travely.SchedulerManager.Repository
{
    public interface IUserScheduleRepository
    {
        void MarkAs(NotificationStatus status, params long[] ids);

        void MarkAs(NotificationStatus status, long scheduleInfoId, params long[] userIds);

        void MarkAllAs(NotificationStatus status, long scheduleInfoId);
    }
}
