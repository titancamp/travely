using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Travely.PropertyManager.Data.Models;

namespace Travely.PropertyManager.Data.EntityFramework
{
    public class PropertyDbContext : DbContext
    {
        public PropertyDbContext(DbContextOptions<PropertyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }

        public DbSet<PropertyAttachment> PropertyAttachments { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType()));
        }
    }
}
