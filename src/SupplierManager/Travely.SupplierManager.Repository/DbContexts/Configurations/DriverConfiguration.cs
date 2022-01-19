using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class DriverConfiguration : IEntityTypeConfiguration<DriverEntity>
    {
        public void Configure(EntityTypeBuilder<DriverEntity> builder)
        {
            builder.Navigation(x => x.LicenseType).AutoInclude();
            builder.Navigation(x => x.Languages).AutoInclude();
        }
    }
}
