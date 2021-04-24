using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourManager.Repository.Entities;

namespace TourManager.Repository.EfCore.Configurations
{
    public class BookingTransportationConfiguration : IEntityTypeConfiguration<BookingTransportationEntity>
    {
        public void Configure(EntityTypeBuilder<BookingTransportationEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(e => e.RoomType).IsRequired(false).HasMaxLength(100);

            builder.HasOne(e => e.Property)
                .WithMany(d => d.BookingTransportations)
                .HasForeignKey(e => e.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}