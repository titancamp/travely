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
            builder.ApplyConfiguration(new ActivitiesConfiguration());
            builder.ApplyConfiguration(new AttributeConfiguration());
            builder.ApplyConfiguration(new FoodConfiguration());
            builder.ApplyConfiguration(new MenuConfiguration());
            builder.ApplyConfiguration(new GuidesConfiguration());
            builder.ApplyConfiguration(new GuideConfiguration());
            builder.ApplyConfiguration(new TransportationConfiguration());
            builder.ApplyConfiguration(new DriverConfiguration());
            builder.ApplyConfiguration(new LicenseTypeConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
        }
    }
}