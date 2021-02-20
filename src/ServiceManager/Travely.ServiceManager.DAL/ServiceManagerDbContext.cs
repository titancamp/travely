using Microsoft.EntityFrameworkCore;
using Travely.ServiceManager.Abstraction.Models.Db;

namespace Travely.ServiceManager.DAL
{
    public class ServiceManagerDbContext : DbContext
    {
        public ServiceManagerDbContext(DbContextOptions<ServiceManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        
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
                .Property(x => x.Name)
                .IsRequired();

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
                .Property(x => x.Website);

            modelBuilder.Entity<Activity>()
                .Property(x => x.Price);

            modelBuilder.Entity<Activity>()
                .Property(x => x.Currency);

            modelBuilder.Entity<Activity>()
                .Property(x => x.Notes);

            modelBuilder.Entity<Activity>()
                .Property(x => x.CreatedDate)
                .IsRequired();

            modelBuilder.Entity<Activity>()
                .Property(x => x.LastUpdatedDate);

            modelBuilder.Entity<Activity>()
                .Property(x => x.ChangeUser);

            modelBuilder.Entity<ActivityType>()
                .HasKey(x => new { x.Id });

            modelBuilder.Entity<ActivityType>()
                .HasIndex(x => new { x.Name, x.AgencyId })
                .IsUnique();

            modelBuilder.Entity<ActivityType>()
                .Property(x => x.AgencyId)
                .IsRequired();

            modelBuilder.Entity<ActivityType>()
                .Property(x => x.Name)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
