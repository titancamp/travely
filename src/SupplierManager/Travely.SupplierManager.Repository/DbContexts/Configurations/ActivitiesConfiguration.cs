using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class ActivitiesConfiguration : IEntityTypeConfiguration<ActivitiesEntity>
    {
        public void Configure(EntityTypeBuilder<ActivitiesEntity> builder)
        {
            builder.ToTable("ActivitiesEntity");
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Cost).HasColumnType("decimal(20, 2)");
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.Notes).HasMaxLength(500);
            builder.Property(e => e.TypeName).HasMaxLength(50);
            
            builder.Navigation(x => x.Attributes).AutoInclude();
            builder.Navigation(x => x.Attachments).AutoInclude();
        }
    }
}