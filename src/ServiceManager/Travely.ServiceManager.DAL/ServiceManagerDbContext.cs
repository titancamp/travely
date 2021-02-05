using Microsoft.EntityFrameworkCore;
using Travely.ServiceManager.Abstraction.Models.Db;

namespace Travely.ServiceManager.DAL.Data
{
    public class ServiceManagerDbContext : DbContext
    {
        public ServiceManagerDbContext(DbContextOptions<ServiceManagerDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Activity>()
                .HasOne<ActivityType>(x => x.ActivityType)
                .WithMany(x => x.Activities)
                .HasForeignKey(x => x.ActivityTypeId);

            modelBuilder.Entity<Activity>()
                .HasIndex(x => new { x.Name, x.ActivityTypeId })
                .IsUnique();

            modelBuilder.Entity<Activity>()
                .Property(x => x.Address)
                .IsRequired();

            modelBuilder.Entity<Activity>()
                .Property(x => x.ContactName)
                .IsRequired();

            modelBuilder.Entity<Activity>()
                .Property(x => x.EmailAddress)
                .IsRequired();

            modelBuilder.Entity<Activity>()
                .Property(x => x.Phone)
                .IsRequired();

            modelBuilder.Entity<Activity>()
                .Property(x => x.Website)
                .IsRequired();

            modelBuilder.Entity<Activity>()
                .Property(x => x.Price);

            modelBuilder.Entity<Activity>()
                .Property(x => x.Currency)
                .IsRequired();

            modelBuilder.Entity<Activity>()
                .Property(x => x.Notes)
                .IsRequired();

            modelBuilder.Entity<Activity>()
                .Property(x => x.ChangeDate)
                .IsRequired();

            modelBuilder.Entity<Activity>()
                .Property(x => x.ChangeUser)
                .IsRequired();

            modelBuilder.Entity<ActivityType>()
                .HasKey(x => new { x.Id });

            modelBuilder.Entity<ActivityType>()
                .HasIndex(x => new { x.ActivityName, x.AgencyId })
                .IsUnique();

            modelBuilder.Entity<ActivityType>()
                .Property(x => x.AgencyId)
                .IsRequired();

            modelBuilder.Entity<ActivityType>()
                .Property(x => x.ActivityName)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
    }
}
