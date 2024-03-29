﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travely.ReportingManager.Data.Models;

namespace Travely.ReportingManager.Data.Infrastructure.Configurations
{
    public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItemEntity>
    {
        public void Configure(EntityTypeBuilder<ToDoItemEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Deadline).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Priority).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
        }
    }
}
