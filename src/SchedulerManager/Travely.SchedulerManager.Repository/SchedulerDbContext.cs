using Microsoft.EntityFrameworkCore;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Repository
{
    public partial class SchedulerDbContext : DbContext
    {
        public SchedulerDbContext()
        {
        }

        public SchedulerDbContext(DbContextOptions<SchedulerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ScheduleMessageTemplate> MessageTemplates { get; set; }
        public virtual DbSet<ScheduleInfo> ScheduleInfos { get; set; }
        public virtual DbSet<UserSchedule> UserSchedules { get; set; }
        public virtual DbSet<ScheduleJob> ScheduleJobs { get; set; }
    }
}