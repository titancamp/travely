using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourManager.Repository.Entities;

namespace TourManager.Repository.EfCore.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
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
        }
    }
}