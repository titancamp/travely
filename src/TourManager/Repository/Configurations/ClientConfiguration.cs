using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.TourManager.Repository.Repositories.Entities;

namespace Travely.TourManager.Repository.Configurations
{
    class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.ExternalId)
                .IsRequired();
        }
    }
}
