using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class TransportationConfiguration : IEntityTypeConfiguration<TransportationEntity>
    {
        public void Configure(EntityTypeBuilder<TransportationEntity> builder)
        {
            builder.ToTable("TransportationEntity");
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Address).HasMaxLength(150);
            builder.Property(e => e.City).HasMaxLength(50);
            builder.Property(e => e.ContactPerson).HasMaxLength(50);
            builder.Property(e => e.CreatedBy).HasMaxLength(50);
            builder.Property(e => e.LastEditedBy).HasMaxLength(50);
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Notes).HasMaxLength(500);

            builder.Navigation(x => x.Location).AutoInclude();
            builder.Navigation(x => x.Drivers).AutoInclude();
            builder.Navigation(x => x.Cars).AutoInclude();
            builder.Navigation(x => x.Attachments).AutoInclude();
        }
    }
}