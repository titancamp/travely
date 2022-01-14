using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class AccommodationConfiguration : IEntityTypeConfiguration<AccommodationEntity>
    {
        public void Configure(EntityTypeBuilder<AccommodationEntity> builder)
        {
            builder.Navigation(x => x.Rooms).AutoInclude();
            builder.Navigation(x => x.Location).AutoInclude();
            builder.Navigation(x => x.Region).AutoInclude();
            builder.Navigation(x => x.Services).AutoInclude();
            builder.Navigation(x => x.Attachments).AutoInclude();
            builder.Navigation(x => x.Type).AutoInclude();
        }
    }
}