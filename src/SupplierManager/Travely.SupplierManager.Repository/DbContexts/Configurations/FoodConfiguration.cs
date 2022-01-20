using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class FoodConfiguration : IEntityTypeConfiguration<FoodEntity>
    {
        public void Configure(EntityTypeBuilder<FoodEntity> builder)
        {
            builder.Navigation(x => x.Location).AutoInclude();
            builder.Navigation(x => x.Menu).AutoInclude();
            builder.Navigation(x => x.Attachments).AutoInclude();
        }
    }
}
