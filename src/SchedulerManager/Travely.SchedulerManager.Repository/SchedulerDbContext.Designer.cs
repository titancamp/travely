using Microsoft.EntityFrameworkCore;
using Travely.SchedulerManager.Repository.Infrastructure.Configurations;

namespace Travely.SchedulerManager.Repository
{
    public partial class SchedulerDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ScheduleMessageTemplateConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleInfoConfiguration());
            modelBuilder.ApplyConfiguration(new UserScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleJobConfiguration());
        }
    }
}
