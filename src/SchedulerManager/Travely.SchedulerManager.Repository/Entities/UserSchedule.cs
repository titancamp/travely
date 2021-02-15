using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travely.SchedulerManager.Repository.Infrastructure.EntityConfigurations;

namespace Travely.SchedulerManager.Repository.Entities
{
    public class UserSchedule: BaseEntity
    {
        public long ScheduleInfoId { get; set; }
        public long UserId { get; set; }
        public byte Status { get; set; }

        public virtual ScheduleInfo ScheduleInfo { get; set; }
    }
}