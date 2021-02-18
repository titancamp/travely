using System;

namespace Travely.SchedulerManager.Repository.Entities
{
    public class ScheduleJob : BaseEntity
    {
        public long ScheduleInfoId { get; set; }
        public string JobId { get; set; }
        public DateTime FireDate { get; set; }

        public virtual ScheduleInfo ScheduleInfo { get; set; }
    }
}