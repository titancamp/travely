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
        /// Gets tour by identifier.
        /// </summary>
        /// <param name="id">The tour identifier.</param>
        /// <param name="includeBookings">If true includes bookings.</param>
        /// <param name="includeClients">If true includes clients.</param>
        /// <returns></returns>
        public Task<TourEntity> GetByIdAsync(int id, bool includeBookings, bool includeClients)
        {
            var query = Context.Set<TourEntity>().AsQueryable();

            if (includeBookings)
            {
                query = query.Include(item => item.Bookings);
            }

            if (includeClients)
            {
                query = query.Include(item => item.TourClients)
                    .ThenInclude(item => item.Client);
            }

            return query.FirstOrDefaultAsync(item => item.Id == id);
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
                .Include(item => item.TourClients)
                .ThenInclude(item => item.Client)
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