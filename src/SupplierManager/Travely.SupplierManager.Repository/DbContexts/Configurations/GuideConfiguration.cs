using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class GuideConfiguration : IEntityTypeConfiguration<GuideEntity>
    {
        public void Configure(EntityTypeBuilder<GuideEntity> builder)
        {
            builder.Navigation(x => x.Languages).AutoInclude();
        }
    }
}

