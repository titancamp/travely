using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class GuideConfiguration : IEntityTypeConfiguration<GuideEntity>
    {
        public void Configure(EntityTypeBuilder<GuideEntity> builder)
        {
            builder.ToTable("GuideEntity");
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Navigation(x => x.Languages).AutoInclude();
        }
    }
}

