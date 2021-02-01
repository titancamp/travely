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

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Activity> Activities { get; set; }
    }
}
