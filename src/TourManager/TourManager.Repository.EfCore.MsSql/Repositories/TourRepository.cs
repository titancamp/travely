﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourManager.Repository.Abstraction;
using TourManager.Repository.EfCore.Context;
using TourManager.Repository.Entities;

namespace TourManager.Repository.EfCore.MsSql.Repositories
{
    /// <summary>
    /// The tour entity's repository
    /// </summary>
    public class TourRepository : BaseRepository<TourEntity>, ITourRepository
    {
        /// <summary>
        /// Create new instance of tour repository
        /// </summary>
        /// <param name="context">The tour db context</param>
        public TourRepository(TourDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Get all tours by tenant
        /// </summary>
        /// <param name="tenantId">The tenant id</param>
        /// <returns></returns>
        public async Task<List<TourEntity>> GetAll(int tenantId)
        {
            return await this.Find(tour => tour.TenantId == tenantId);
        }

        /// <summary>
        /// Get all tours starting from now
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TourEntity>> GetAllFromToday()
        {
            var query = DbSet.AsNoTracking()
                .Where(a => a.StartDate > DateTime.Now);

            return await query.ToListAsync();
        }
    }
}