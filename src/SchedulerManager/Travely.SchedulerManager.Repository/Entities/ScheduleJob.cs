using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travely.SchedulerManager.Repository.Infrastructure.EntityConfigurations;

namespace Travely.SchedulerManager.Repository.Entities
{
    public class ScheduleJob : BaseEntity
    {
        public long Id { get; set; }
        public long UserScheduleId { get; set; }
        public string JobId { get; set; }
        public TimeSpan FireDate { get; set; }

        public virtual UserSchedule UserSchedule { get; set; }
    }
}