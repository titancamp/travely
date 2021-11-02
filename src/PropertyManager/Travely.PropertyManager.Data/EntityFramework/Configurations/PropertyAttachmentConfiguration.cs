using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.PropertyManager.Data.Models;

namespace Travely.PropertyManager.Data.EntityFramework.Configurations
{
    public class PropertyAttachmentConfiguration : IEntityTypeConfiguration<PropertyAttachment>
    {
        public void Configure(EntityTypeBuilder<PropertyAttachment> builder)
        {
            builder.ToTable(nameof(PropertyAttachment))
                .HasKey(e => e.Id);

            builder.Property(p => p.FileId).IsUnicode(false).HasMaxLength(36);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(e => e.Property)
                .WithMany(d => d.Attachments)
                .HasForeignKey(e => e.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
