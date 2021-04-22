using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.PropertyManager.Data.Models;

namespace Travely.PropertyManager.Data.EntityFramework.Configurations
{
    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.ToTable(nameof(RoomType))
                .HasKey(e => e.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

            builder.HasData(new[]
            {
                new RoomType { Id = 1, Name = "Single" },
                new RoomType { Id = 2, Name = "Double" },
                new RoomType { Id = 3, Name = "Triple" },
                new RoomType { Id = 4, Name = "Quad" },
                new RoomType { Id = 5, Name = "Queen" },
                new RoomType { Id = 6, Name = "King" },
                new RoomType { Id = 7, Name = "Twin" },
                new RoomType { Id = 8, Name = "Double-double" },
                new RoomType { Id = 9, Name = "Studio" },
            });
        }
    }
}
