using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourManager.Repository.Entities;

namespace TourManager.Repository.EfCore.Configurations
{
    public class BookingServiceConfiguration : IEntityTypeConfiguration<BookingServiceEntity>
    {
        public void Configure(EntityTypeBuilder<BookingServiceEntity> builder)
        {
            builder.HasKey(a => a.Id);
        }
    }
}