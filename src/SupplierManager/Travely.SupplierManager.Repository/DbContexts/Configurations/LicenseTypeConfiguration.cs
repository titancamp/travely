using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class LicenseTypeConfiguration : IEntityTypeConfiguration<LicenseTypeEntity>
    {
        public void Configure(EntityTypeBuilder<LicenseTypeEntity> builder)
        {
            builder.ToTable("LicenseTypeEntity");
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).IsRequired();

            builder.HasOne(d => d.Driver)
                .WithMany(p => p.LicenseTypes)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

