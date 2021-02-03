using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Travely.PropertyManager.Domain.Entities;

namespace Travely.PropertyManager.Data.EntityFramework
{
    public class PropertyDbContext : DbContext
    {
        public PropertyDbContext(DbContextOptions<PropertyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType()));
        }
    }
}
