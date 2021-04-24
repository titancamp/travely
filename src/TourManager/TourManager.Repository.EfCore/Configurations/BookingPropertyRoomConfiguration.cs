using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourManager.Repository.Entities;

namespace TourManager.Repository.EfCore.Configurations
{
    public class BookingPropertyRoomConfiguration : IEntityTypeConfiguration<BookingPropertyRoomEntity>
    {
        public void Configure(EntityTypeBuilder<BookingPropertyRoomEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(m => m.BookingPropertyRoomGuests)
                .WithOne(m => m.BookingPropertyRoom)
                .HasForeignKey(m => m.BookingPropertyRoomId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}