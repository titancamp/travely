using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class AccommodationServiceConfiguration : IEntityTypeConfiguration<AccommodationServiceEntity>
    {
        public void Configure(EntityTypeBuilder<AccommodationServiceEntity> builder)
        {
            builder.HasKey(a => a.Id);
        }
    }
}