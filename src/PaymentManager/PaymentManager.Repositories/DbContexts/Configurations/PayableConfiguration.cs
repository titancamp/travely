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
    internal class PayableConfiguration : IEntityTypeConfiguration<PayableEntity>
    {
        public void Configure(EntityTypeBuilder<PayableEntity> builder)
        {
            builder.HasKey(e => e.Id);
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
                .Property(e => e.SupplierId)
                .IsRequired();
            builder
                .Property(e => e.SupplierName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(e => e.Status)
                .HasDefaultValue(PaymentStatus.Unpaid);
            builder
                .Property(e => e.PlannedCost)
                .HasColumnType("decimal(18,4)");
            builder
                .Property(e => e.ActualCost)
                .HasColumnType("decimal(18,4)");
            builder
                .Property(e => e.Difference)
                .HasColumnType("decimal(18,4)");
            builder
                .Property(e => e.Paid)
                .HasColumnType("decimal(18,4)");
            builder
                .Property(e => e.Remaining)
                .HasColumnType("decimal(18,4)");
        }
    }
}
