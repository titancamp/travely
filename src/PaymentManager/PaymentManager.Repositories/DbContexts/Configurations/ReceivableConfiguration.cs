using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentManager.Repositories.Entities;
using PaymentManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Repositories.DbContexts
{
    internal class ReceivableConfiguration : IEntityTypeConfiguration<ReceivableEntity>
    {
        public void Configure(EntityTypeBuilder<ReceivableEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder
                .Property(e => e.TourId)
                .IsRequired();
            builder
                .Property(e => e.TourName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(e => e.TourStatus)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(e => e.PartnerId)
                .IsRequired();
            builder
                .Property(e => e.PartnerName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(e => e.Status)
                .IsRequired()
                .HasDefaultValue(PaymentStatus.Unpaid);
            builder
                .Property(e => e.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,4)");
            builder
                .Property(e => e.PaidAmount)
                .HasColumnType("decimal(18,4)")
                .HasDefaultValue(0);
            builder
                .Property(e => e.Remaining)
                .HasColumnType("decimal(18,4)");
                //.HasDefaultValueSql("[TotalAmount]");
            builder
                .Property(e => e.Rate)
                .HasColumnType("decimal(18,4)");
            builder
                .Property(e => e.Note)
                .HasMaxLength(200);
        }
    }
}