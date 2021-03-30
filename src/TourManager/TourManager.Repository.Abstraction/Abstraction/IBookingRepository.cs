using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Repository.Entities;
using TourManager.Repository.Models;

namespace TourManager.Repository.Abstraction
{
    /// <summary>
    /// The booking repository interface
    /// </summary>
    public interface IBookingRepository : IRepository<BookingEntity>
    {
        /// <summary>
        /// Get bookings
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <returns></returns>
        Task<List<BookingEntity>> Get(GetBookingFilter filter);
    }
}