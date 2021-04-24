using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TourManager.Repository.Entities;

namespace TourManager.Repository.EfCore.Context
{
    public class TourDbContext : DbContext
    {
        public DbSet<TourEntity> Tours { get; set; }

        public DbSet<BookingEntity> Bookings { get; set; }

        public DbSet<BookingPropertyEntity> BookingProperties { get; set; }

        public DbSet<BookingPropertyRoomEntity> BookingPropertyRooms { get; set; }

        public DbSet<BookingPropertyRoomGuestEntity> BookingPropertyRoomGuests { get; set; }

        public DbSet<BookingServiceEntity> BookingServices { get; set; }

        public DbSet<BookingTransportationEntity> BookingTransportations { get; set; }

        public DbSet<PropertyEntity> Properties { get; set; }

        public DbSet<ClientEntity> Clients { get; set; }

        public DbSet<TourClientEntity> TourClients { get; set; }

        public TourDbContext(DbContextOptions<TourDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType()));
        }
    }
}