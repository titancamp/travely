using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class ActivitiesConfiguration : IEntityTypeConfiguration<ActivitiesEntity>
    {
        public void Configure(EntityTypeBuilder<ActivitiesEntity> builder)
        {
            builder.Navigation(x => x.Attributes).AutoInclude();
            builder.Navigation(x => x.Attachments).AutoInclude();
        }
    }
}