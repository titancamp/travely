using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travely.SchedulerManager.Repository.Infrastructure.EntityConfigurations;

namespace Travely.SchedulerManager.Repository.Entities
{
    public class ScheduleInfo: BaseEntity
    {
        public long MessageTemplateId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int RecurseId { get; set; }
        public string JsonData { get; set; }
        public int Module { get; set; }

        public virtual MessageTemplate MessageTemplate { get; set; }
        public virtual ICollection<UserSchedule> UserSchedules { get; set; }
        public virtual ICollection<ScheduleJob> ScheduleJobs { get; set; }
    }
}