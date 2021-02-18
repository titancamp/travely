using Travely.SchedulerManager.Common.Enums;

namespace Travely.SchedulerManager.Repository.Entities
{
    public class UserSchedule: BaseEntity
    {
        public long UserId { get; set; }
        public long ScheduleInfoId { get; set; }
        public NotificationStatus Status { get; set; }

        public virtual ScheduleInfo ScheduleInfo { get; set; }
    }
}