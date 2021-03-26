using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourManager.Repository.Abstraction;
using TourManager.Repository.EfCore.Context;
using TourManager.Repository.Entities;
using TourManager.Repository.Models;

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
        /// Get tours
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <returns></returns>
        public Task<List<TourEntity>> Get(GetTourFilter filter)
        {
            var query = DbSet
                .AsNoTracking()
                .Where(x => x.AgencyId == filter.AgencyId);

            if (filter.StartDate != null)
            {
                query = query.Where(x => x.StartDate >= filter.StartDate);
            }

            if (filter.EndDate != null)
            {
                query = query.Where(x => x.EndDate <= filter.EndDate);
            }

            return query.ToListAsync();
        }
    }
}