using Microsoft.EntityFrameworkCore;
using Travely.TourManager.Repository.Configurations;
using Travely.TourManager.Repository.Repositories.Entities;

namespace Travely.TourManager.Repository.Repositories
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
