using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travely.SchedulerManager.Repository.Entities
{
    public class MessageTemplate
    {
        public MessageTemplate()
        {
            ScheduleInfos = new HashSet<ScheduleInfo>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string TemplateName { get; set; }
        [Required]
        public string Template { get; set; }

        public virtual ICollection<ScheduleInfo> ScheduleInfos { get; set; }
    }
}