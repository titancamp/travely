using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class RoomConfiguration : IEntityTypeConfiguration<RoomEntity>
    {
        public void Configure(EntityTypeBuilder<RoomEntity> builder)
        {
            builder.ToTable("RoomEntity");
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Price).HasColumnType("decimal(20, 2)");
            builder.HasOne(d => d.Accommodation)
                .WithMany(p => p.Rooms);
            
            builder.Navigation(x => x.Services).AutoInclude();
        }
    }
}