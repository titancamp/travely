using Microsoft.EntityFrameworkCore;
using TourManager.Repository.EfCore.Configurations;
using TourManager.Repository.EfCore.Entities;

namespace TourManager.Repository.EfCore.Context
{
    public class TourContext : DbContext
    {
        public DbSet<Tour> Tours { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<TourClient> TourClients { get; set; }


        public TourContext(DbContextOptions<TourContext> options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new TourConfiguration());


            builder
                .ApplyConfiguration(new BookingConfiguration());


            builder
                .ApplyConfiguration(new ClientConfiguration());


            builder
                .ApplyConfiguration(new TourClientConfiguration());
        }
    }
}