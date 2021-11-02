using System.Text.Json;
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

            builder
                .Property(m => m.ExternalId)
                .IsRequired();

            builder
                .Property(m => m.BookingProperty)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<BookingPropertyEntity>(v, null));

            builder
                .Property(m => m.BookingService)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<BookingServiceEntity>(v, null));
        }
    }
}