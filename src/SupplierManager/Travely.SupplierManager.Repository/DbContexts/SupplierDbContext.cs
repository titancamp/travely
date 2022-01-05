using Microsoft.EntityFrameworkCore;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class SupplierDbContext : DbContext
    {
        public SupplierDbContext(DbContextOptions<SupplierDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccommodationConfiguration());
            builder.ApplyConfiguration(new AccommodationServiceConfiguration());
            builder.ApplyConfiguration(new AttachmentConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());
            builder.ApplyConfiguration(new RoomConfiguration());
            builder.ApplyConfiguration(new RoomServiceConfiguration());
        }
    }
}