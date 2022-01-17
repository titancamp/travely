using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class GuidesConfiguration : IEntityTypeConfiguration<GuidesEntity>
    {
        public void Configure(EntityTypeBuilder<GuidesEntity> builder)
        {
            builder.Navigation(x => x.Location).AutoInclude();
            builder.Navigation(x => x.Guide).AutoInclude();
            builder.Navigation(x => x.Attachments).AutoInclude();
        }
    }
}
