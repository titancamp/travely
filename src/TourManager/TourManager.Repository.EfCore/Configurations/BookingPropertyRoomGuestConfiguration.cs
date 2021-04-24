using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourManager.Repository.Entities;

namespace TourManager.Repository.EfCore.Configurations
{
    public class BookingPropertyRoomGuestConfiguration : IEntityTypeConfiguration<BookingPropertyRoomGuestEntity>
    {
        public void Configure(EntityTypeBuilder<BookingPropertyRoomGuestEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Client)
                .WithMany()
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}