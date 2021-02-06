using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travely.SchedulerManager.Repository.Entities
{
    public class UserSchedule
    {
        [Key]
        public int Id { get; set; }
        public int ScheduleInfoId { get; set; }
        public int UserId { get; set; }
        public byte Status { get; set; }

        [ForeignKey(nameof(ScheduleInfoId))]
        public virtual ScheduleInfo ScheduleInfo { get; set; }
    }
}