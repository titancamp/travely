using System.Collections.Generic;
using Travely.SchedulerManager.Common.Enums;

namespace Travely.SchedulerManager.Repository.Entities
{
    public class ScheduleMessageTemplate: BaseEntity
    {
        public MessageTemplate TemplateName { get; set; }
        public string Template { get; set; }

        public virtual ICollection<ScheduleInfo> ScheduleInfos { get; set; }
    }
}