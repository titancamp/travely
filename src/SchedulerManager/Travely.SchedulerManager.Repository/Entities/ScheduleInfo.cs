using System;
using System.Collections.Generic;
using Travely.SchedulerManager.Common.Enums;

namespace Travely.SchedulerManager.Repository.Entities
{
    public class ScheduleInfo: BaseEntity
    {
        public long MessageTemplateId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string JsonData { get; set; }
        public long RecurseId { get; set; }
        public TravelyModule Module { get; set; }

        public virtual ScheduleMessageTemplate ScheduleMessageTemplate { get; set; }
        public virtual ICollection<UserSchedule> UserSchedules { get; set; }
        public virtual ICollection<ScheduleJob> ScheduleJobs { get; set; }
    }
}