using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class CarConfiguration : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).IsRequired();
            builder.ToTable("CarEntity");
            builder.Property(e => e.Color).HasMaxLength(50);
            builder.Property(e => e.Model).HasMaxLength(50);
            builder.Property(e => e.PlateNumber).HasMaxLength(10);
            builder.HasOne(d => d.Transportation)
                .WithMany(p => p.Cars);
        }
    }
}

