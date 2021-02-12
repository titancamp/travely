using Microsoft.EntityFrameworkCore;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Repository
{
    public class SchedulerDbContext : DbContext
    {
        public SchedulerDbContext()
        {
        }

        public SchedulerDbContext(DbContextOptions<SchedulerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MessageTemplate> MessageTemplates { get; set; }
        public virtual DbSet<ScheduleInfo> ScheduleInfos { get; set; }
        public virtual DbSet<UserSchedule> UserSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageTemplate>(entity =>
            {
                entity.Property(e => e.Template).IsRequired();

                entity.Property(e => e.TemplateName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<ScheduleInfo>(entity =>
            {
                entity.HasIndex(e => e.MessageTemplateId, "IX_ScheduleInfos_MessageTemplateId");

                entity.Property(e => e.JsonData).IsRequired();

                entity.HasOne(d => d.MessageTemplate)
                    .WithMany(p => p.ScheduleInfos)
                    .HasForeignKey(d => d.MessageTemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_MessageTemplate");
            });

            modelBuilder.Entity<UserSchedule>(entity =>
            {
                entity.HasIndex(e => e.ScheduleInfoId, "IX_UserSchedules_ScheduleInfoId");

                entity.HasOne(d => d.ScheduleInfo)
                    .WithMany(p => p.UserSchedules)
                    .HasForeignKey(d => d.ScheduleInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSchedule_Schedule");
            });
        }
    }
}