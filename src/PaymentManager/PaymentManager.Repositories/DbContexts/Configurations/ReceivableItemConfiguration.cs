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
    internal class ReceivableItemConfiguration : IEntityTypeConfiguration<ReceivableItemEntity>
    {
        public void Configure(EntityTypeBuilder<ReceivableItemEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder
                .Property(e => e.InvoiceId)
                .HasMaxLength(50);
            builder
                .Property(e => e.InvoiceSent)
                .HasDefaultValue(false);
            builder
                .Property(e => e.PaidAmount)
                .IsRequired()
                .HasColumnType("decimal(18,4)");
            builder
                .Property(e => e.PaymentDate)
                .IsRequired();
            builder
                .Property(e => e.PaymentType)
                .IsRequired();
        }
    }
}