using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Repository.Infrastructure.Configurations
{
    class UserScheduleConfiguration : IEntityTypeConfiguration<UserSchedule>
    {
        public void Configure(EntityTypeBuilder<UserSchedule> builder)
        {
            builder.HasIndex(e => e.ScheduleInfoId, "IX_UserSchedules_ScheduleInfoId");

            builder.HasOne(d => d.ScheduleInfo)
                .WithMany(p => p.UserSchedules)
                .HasForeignKey(d => d.ScheduleInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserSchedule_Schedule");

            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
