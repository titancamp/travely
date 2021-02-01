using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourManager.Repository.EfCore.Entities;

namespace TourManager.Repository.EfCore.Configurations
{
    internal class TourClientConfiguration : IEntityTypeConfiguration<TourClient>
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