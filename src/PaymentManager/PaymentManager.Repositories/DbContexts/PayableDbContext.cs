﻿using Microsoft.EntityFrameworkCore;
using PaymentManager.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Repositories.DbContexts
{
    public class PayableDbContext : DbContext
    {
        public DbSet<PayableEntity> Payables;
        public DbSet<PayableItemEntity> PayableItems { get; set; }

        //public DbSet<AttachmentEntity> Attachments { get; set; }

        public PayableDbContext(DbContextOptions<PayableDbContext> options)
            : base(options)
        {
            Payables = Set<PayableEntity>();
            PayableItems = Set<PayableItemEntity>();
            //Attachments = Set<AttachmentEntity>();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType()));
            builder.ApplyConfiguration(new PayableConfiguration());
            builder.ApplyConfiguration(new PayableItemConfiguration());
        }
    }
}
