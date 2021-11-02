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
    /// The booking entity's repository
    /// </summary>
    public class BookingRepository : BaseRepository<BookingEntity>, IBookingRepository
    {
        /// <summary>
        /// Create new instance of booking repository
        /// </summary>
        /// <param name="context">The booking db context</param>
        public BookingRepository(TourDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Get bookings
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <returns></returns>
        public Task<List<BookingEntity>> Get(GetBookingFilter filter)
        {
            var query = DbSet
              .AsNoTracking()
              .Include(item => item.Tour)
              .Where(x => x.Tour.AgencyId == filter.AgencyId);

            if (filter.TourId.HasValue)
            {
                query = query.Where(item => item.TourId == filter.TourId.Value);
            }

            if (filter.CancellationDeadlineFrom.HasValue)
            {
                query = query.Where(x => x.BookingProperty.CancellationDeadline >= filter.CancellationDeadlineFrom);
            }

            return query.ToListAsync();
        }
    }
}