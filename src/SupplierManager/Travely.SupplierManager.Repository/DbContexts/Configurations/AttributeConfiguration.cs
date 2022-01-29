using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class AttributeConfiguration : IEntityTypeConfiguration<AttributeEntity>
    {
        public void Configure(EntityTypeBuilder<AttributeEntity> builder)
        {
            builder.ToTable("AttributeEntity");
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).IsRequired();
            builder.ToTable("AttributeEntity");
            builder.Property(e => e.Name).HasMaxLength(30);
        }
    }
}