using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Repository.Infrastructure.Configurations
{
    class ScheduleInfoConfiguration : IEntityTypeConfiguration<ScheduleInfo>
    {
        public void Configure(EntityTypeBuilder<ScheduleInfo> builder)
        {
            builder.HasIndex(e => e.MessageTemplateId, "IX_ScheduleInfos_MessageTemplateId");

            builder.Property(e => e.JsonData).IsRequired();

            builder.HasOne(d => d.ScheduleMessageTemplate)
                .WithMany(p => p.ScheduleInfos)
                .HasForeignKey(d => d.MessageTemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_MessageTemplate");

            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
