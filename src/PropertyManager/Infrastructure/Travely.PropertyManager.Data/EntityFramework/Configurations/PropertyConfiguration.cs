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

            builder.Property(p => p.Name).HasMaxLength(100); 
        }
    }
}
