using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class GuidesConfiguration : IEntityTypeConfiguration<GuidesEntity>
    {
        public void Configure(EntityTypeBuilder<GuidesEntity> builder)
        {
            builder.ToTable("GuidesEntity");

            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Address).HasMaxLength(150);
            builder.Property(e => e.City).HasMaxLength(50);
            builder.Property(e => e.ContactPerson).HasMaxLength(50);
            builder.Property(e => e.Cost).HasColumnType("decimal(20, 2)");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Notes).HasMaxLength(500);
            
            builder.Navigation(x => x.Location).AutoInclude();
            builder.Navigation(x => x.Guides).AutoInclude();
            builder.Navigation(x => x.Attachments).AutoInclude();
        }
    }
}
