using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourManager.Repository.EfCore.Entities;

namespace TourManager.Repository.EfCore.Configurations
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
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