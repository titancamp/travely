using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            Expression<Func<BookingEntity, bool>> filterExp = x => x.Tour.AgencyId == filter.AgencyId;

            if (filter.TourId != null)
            {
                var compiled = filterExp.Compile();
                filterExp = x => compiled(x) && x.TourId == filter.TourId;
            }

            if (filter.CancellationDeadlineFrom != null)
            {
                var compiled = filterExp.Compile();
                filterExp = x => compiled(x) && x.CancellationDeadline >= filter.CancellationDeadlineFrom;
            }

            return this.Find(filterExp);
        }
    }
}