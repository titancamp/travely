using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Travely.SchedulerManager.Repository.Infrastructure.EntityConfigurations;

namespace Travely.SchedulerManager.Repository.Entities
{
    public class MessageTemplate: BaseEntity
    {
        public MessageTemplate()
        {
            ScheduleInfos = new HashSet<ScheduleInfo>();
        }

        public string TemplateName { get; set; }
        public string Template { get; set; }

        public virtual ICollection<ScheduleInfo> ScheduleInfos { get; set; }
    }
}