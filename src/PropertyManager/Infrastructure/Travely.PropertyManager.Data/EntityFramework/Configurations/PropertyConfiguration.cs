using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.PropertyManager.Domain.Entities;

namespace Travely.PropertyManager.Data.EntityFramework.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable(nameof(Property))
                .HasKey(e => e.Id);
  
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Longitude).HasPrecision(9,6); 
            builder.Property(p => p.Latitude).HasPrecision(8,6);
            builder.Property(p => p.Email).HasMaxLength(320);
            builder.Property(p => p.Phone).HasMaxLength(15);

        }
    }
}
