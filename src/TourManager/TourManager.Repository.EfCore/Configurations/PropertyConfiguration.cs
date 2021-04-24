using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourManager.Repository.Entities;

namespace TourManager.Repository.EfCore.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<PropertyEntity>
    {
        public void Configure(EntityTypeBuilder<PropertyEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(m => m.Id).ValueGeneratedNever();
            builder.Property(m => m.Name).IsRequired().HasMaxLength(300);
            builder.Property(m => m.Address).HasMaxLength(1000);
        }
    }
}