using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class RoomServiceConfiguration : IEntityTypeConfiguration<RoomServiceEntity>
    {
        public void Configure(EntityTypeBuilder<RoomServiceEntity> builder)
        {
            builder.HasKey(a => a.Id);
        }
    }
}