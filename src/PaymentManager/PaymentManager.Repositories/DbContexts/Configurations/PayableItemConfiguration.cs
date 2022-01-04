using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentManager.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Repositories.DbContexts
{
    internal class PayableItemConfiguration : IEntityTypeConfiguration<PayableItemEntity>
    {
        public void Configure(EntityTypeBuilder<PayableItemEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder
                .Property(e => e.Note)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(e => e.PaidAmount)
                .HasColumnType("decimal(18,4)");
        }
    }
}
