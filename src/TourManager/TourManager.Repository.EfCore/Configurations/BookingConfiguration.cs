using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourManager.Repository.Entities;

namespace TourManager.Repository.EfCore.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .HasOne(m => m.Tour)
                .WithMany(a => a.Bookings)
                .HasForeignKey(m => m.TourId);

            builder.HasOne(m => m.BookingProperty)
                .WithOne(m => m.Booking)
                .HasForeignKey<BookingPropertyEntity>(m => m.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.BookingService)
                .WithOne(m => m.Booking)
                .HasForeignKey<BookingServiceEntity>(m => m.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.BookingTransportation)
                .WithOne(m => m.Booking)
                .HasForeignKey<BookingTransportationEntity>(m => m.BookingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}