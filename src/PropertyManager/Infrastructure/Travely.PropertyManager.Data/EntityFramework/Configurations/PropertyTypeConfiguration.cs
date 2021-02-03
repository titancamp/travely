using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.PropertyManager.Domain.Entities;

namespace Travely.PropertyManager.Data.EntityFramework.Configurations
{
    public class PropertyTypeConfiguration : IEntityTypeConfiguration<PropertyType>
    {
        public void Configure(EntityTypeBuilder<PropertyType> builder)
        {
            builder.ToTable(nameof(PropertyType))
               .HasKey(e => e.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}
