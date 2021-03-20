﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourManager.Repository.Entities;

namespace TourManager.Repository.EfCore.Configurations
{
    public class TourConfiguration : IEntityTypeConfiguration<TourEntity>
    {
        public void Configure(EntityTypeBuilder<TourEntity> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(m => m.Tenant)
                .WithMany(a => a.TourEntities)
                .HasForeignKey(m => m.TenantId);
        }
    }
}