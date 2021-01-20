using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.TourManager.Repository.Repositories.Entities;

namespace Travely.TourManager.Repository.Configurations
{
    class TourClientConfiguration : IEntityTypeConfiguration<TourClient>
    {
        public void Configure(EntityTypeBuilder<TourClient> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .HasOne(m => m.Tour)
                .WithMany(a => a.TourClients)
                .HasForeignKey(m => m.TourId);


            builder
                .HasOne(m => m.Client)
                .WithMany(a => a.TourClients)
                .HasForeignKey(m => m.ClientId);
        }
    }
}
