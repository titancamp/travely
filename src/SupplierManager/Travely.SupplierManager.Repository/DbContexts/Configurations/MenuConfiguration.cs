using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.DbContexts
{
    public class MenuConfiguration : IEntityTypeConfiguration<MenuEntity>
    {
        public void Configure(EntityTypeBuilder<MenuEntity> builder)
        {
            builder.ToTable("MenuEntity");
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).IsRequired();
            
            builder.Navigation(x => x.Tags).AutoInclude();
            builder.Navigation(x => x.Attachments).AutoInclude();
        }
    }
}

