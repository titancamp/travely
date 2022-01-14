using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class TransportationConfiguration : IEntityTypeConfiguration<TransportationEntity>
    {
        public void Configure(EntityTypeBuilder<TransportationEntity> builder)
        {
            builder.Navigation(x => x.Type).AutoInclude();
            builder.Navigation(x => x.Location).AutoInclude();
            builder.Navigation(x => x.Region).AutoInclude();
            builder.Navigation(x => x.Drivers).AutoInclude();
            builder.Navigation(x => x.Cars).AutoInclude();
            builder.Navigation(x => x.Attachments).AutoInclude();
        }
    }
}