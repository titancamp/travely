using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class AccommodationConfiguration : IEntityTypeConfiguration<AccommodationEntity>
    {
        public void Configure(EntityTypeBuilder<AccommodationEntity> builder)
        {
            builder.ToTable("AccommodationEntity");
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Address).HasMaxLength(150);
            builder.Property(e => e.City).HasMaxLength(50);
            builder.Property(e => e.ContactPerson).HasMaxLength(50);
            builder.Property(e => e.Cost).HasColumnType("decimal(20, 2)");
            builder.Property(e => e.CreatedBy).HasMaxLength(50);
            builder.Property(e => e.LastEditedBy).HasMaxLength(50);
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Notes).HasMaxLength(500);
            builder.Property(e => e.Status).HasMaxLength(50);
            
            builder.Navigation(x => x.Rooms).AutoInclude();
            builder.Navigation(x => x.Location).AutoInclude();
            builder.Navigation(x => x.Services).AutoInclude();
            builder.Navigation(x => x.Attachments).AutoInclude();
        }
    }
}