using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travely.SchedulerManager.Repository.Entities
{
    public class ScheduleInfo
    {
        public ScheduleInfo()
        {
            UserSchedules = new HashSet<UserSchedule>();
        }

        [Key]
        public int Id { get; set; }
        public int MessageTemplateId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int RecurseId { get; set; }
        [Required]
        public string JsonData { get; set; }
        public int Module { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [ForeignKey(nameof(MessageTemplateId))]
        public virtual MessageTemplate MessageTemplate { get; set; }

        public virtual ICollection<UserSchedule> UserSchedules { get; set; }
    }
}