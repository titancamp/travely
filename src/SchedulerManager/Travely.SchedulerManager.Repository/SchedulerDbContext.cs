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

        public virtual DbSet<ScheduleMessageTemplate> MessageTemplates { get; set; }
        public virtual DbSet<ScheduleInfo> ScheduleInfos { get; set; }
        public virtual DbSet<UserSchedule> UserSchedules { get; set; }
        public virtual DbSet<ScheduleJob> ScheduleJobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScheduleMessageTemplate>(entity =>
            {
                entity.Property(e => e.Template).IsRequired();

                entity.Property(e => e.TemplateName)
                    .IsRequired()
                    .HasMaxLength(250);
                
                entity.HasQueryFilter(s => !s.IsDeleted);
            });

            modelBuilder.Entity<ScheduleInfo>(entity =>
            {
                entity.HasIndex(e => e.MessageTemplateId, "IX_ScheduleInfos_MessageTemplateId");

                entity.Property(e => e.JsonData).IsRequired();

                entity.HasOne(d => d.ScheduleMessageTemplate)
                    .WithMany(p => p.ScheduleInfos)
                    .HasForeignKey(d => d.MessageTemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_MessageTemplate");
                
                entity.HasQueryFilter(s => !s.IsDeleted);
            });

            modelBuilder.Entity<UserSchedule>(entity =>
            {
                entity.HasIndex(e => e.ScheduleInfoId, "IX_UserSchedules_ScheduleInfoId");

                entity.HasOne(d => d.ScheduleInfo)
                    .WithMany(p => p.UserSchedules)
                    .HasForeignKey(d => d.ScheduleInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSchedule_Schedule");
                
                entity.HasQueryFilter(s => !s.IsDeleted);
            });

            modelBuilder.Entity<ScheduleJob>(entity =>
            {
                entity.HasIndex(e => e.ScheduleInfoId, "IX_ScheduleJobs_ScheduleInfoId");
                
                entity.Property(e => e.JobId).IsRequired();

                entity.HasOne(d => d.ScheduleInfo)
                    .WithMany(p => p.ScheduleJobs)
                    .HasForeignKey(d => d.ScheduleInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleJobs_Schedule");

                entity.HasQueryFilter(s => !s.IsDeleted);
            });
        }
    }
}