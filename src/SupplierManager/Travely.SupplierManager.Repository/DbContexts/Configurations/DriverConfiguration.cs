using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class DriverConfiguration : IEntityTypeConfiguration<DriverEntity>
    {
        public void Configure(EntityTypeBuilder<DriverEntity> builder)
        {
            builder.ToTable("DriverEntity");
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasOne(d => d.Transportation)
                .WithMany(p => p.Drivers)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Navigation(x => x.LicenseTypes).AutoInclude();
            builder.Navigation(x => x.Languages).AutoInclude();
        }
    }
}
