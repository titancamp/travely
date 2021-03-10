using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Repository.Infrastructure.Configurations
{
    class ScheduleMessageTemplateConfiguration : IEntityTypeConfiguration<ScheduleMessageTemplate>
    {
        public void Configure(EntityTypeBuilder<ScheduleMessageTemplate> builder)
        {
            builder.Property(e => e.Template).IsRequired();

            builder.Property(e => e.TemplateName)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
