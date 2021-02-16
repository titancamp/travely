using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Repository.Abstraction;
using TourManager.Repository.EfCore.Context;
using TourManager.Repository.Entities;

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
        /// Get all bookings of a tour
        /// </summary>
        /// <param name="tourId">The tour id</param>
        /// <returns></returns>
        public Task<List<BookingEntity>> GetAll(int tourId)
        {
            return this.Find(booking => booking.TourId == tourId);
        }
    }
}