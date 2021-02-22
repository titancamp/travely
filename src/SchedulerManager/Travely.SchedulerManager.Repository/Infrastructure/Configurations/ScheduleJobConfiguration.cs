using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Repository.Infrastructure.Configurations
{
    class ScheduleJobConfiguration : IEntityTypeConfiguration<ScheduleJob>
    {
        public void Configure(EntityTypeBuilder<ScheduleJob> builder)
        {
            builder.HasIndex(e => e.ScheduleInfoId, "IX_ScheduleJobs_ScheduleInfoId");

            builder.Property(e => e.JobId).IsRequired();

            builder.HasOne(d => d.ScheduleInfo)
                .WithMany(p => p.ScheduleJobs)
                .HasForeignKey(d => d.ScheduleInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ScheduleJobs_Schedule");

            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
