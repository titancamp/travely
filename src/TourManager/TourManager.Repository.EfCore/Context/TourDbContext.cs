using Microsoft.EntityFrameworkCore;
using TourManager.Repository.EfCore.Configurations;
using TourManager.Repository.Entities;

namespace TourManager.Repository.EfCore.Context
{
    public class TourDbContext : DbContext
    {
        public DbSet<TenantEntity> Tenants { get; set; }
        public DbSet<TourEntity> Tours { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<TourClientEntity> TourClients { get; set; }

        public TourDbContext(DbContextOptions<TourDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TenantConfiguration());
            builder.ApplyConfiguration(new TourConfiguration());
            builder.ApplyConfiguration(new BookingConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new TourClientConfiguration());
        }
    }
}