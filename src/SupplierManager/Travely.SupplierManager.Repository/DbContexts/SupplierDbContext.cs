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
            builder.ApplyConfiguration(new RoomConfiguration());
            builder.ApplyConfiguration(new RoomServiceConfiguration());
            builder.ApplyConfiguration(new ActivitiesConfiguration());
            builder.ApplyConfiguration(new FoodConfiguration());
            builder.ApplyConfiguration(new MenuConfiguration());
            builder.ApplyConfiguration(new GuidesConfiguration());
            builder.ApplyConfiguration(new TransportationConfiguration());
        }
    }
}