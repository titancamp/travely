using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourManager.Repository.Entities;

namespace TourManager.Repository.EfCore.Configurations
{
    public class BookingPropertyConfiguration : IEntityTypeConfiguration<BookingPropertyEntity>
    {
        public void Configure(EntityTypeBuilder<BookingPropertyEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(e => e.Origin).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.ArrivalFlightNumber).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.DepartureFlightNumber).IsRequired(false).HasMaxLength(100);

            builder
                .HasOne(m => m.Property)
                .WithMany(a => a.BookingProperties)
                .HasForeignKey(m => m.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.BookingPropertyRooms)
                .WithOne(m => m.BookingProperty)
                .HasForeignKey(m => m.BookingPropertyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}