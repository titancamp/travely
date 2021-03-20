using System;
using System.Collections.Generic;
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
        public Task<List<TourEntity>> GetAll(int tenantId)
        {
            return this.Find(tour => tour.TenantId == tenantId);
        }

        /// <summary>
        /// Get all tours starting from now
        /// </summary>
        /// <returns></returns>
        public Task<List<TourEntity>> GetAllFromToday()
        {
            return this.Find(tour => tour.StartDate > DateTime.Now);
        }
    }
}