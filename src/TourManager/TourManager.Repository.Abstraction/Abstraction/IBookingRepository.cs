using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Repository.Entities;

namespace TourManager.Repository.Abstraction
{
    /// <summary>
    /// The booking repository interface
    /// </summary>
    public interface IBookingRepository : IRepository<BookingEntity>
    {
        /// <summary>
        ///  Get all bookings of a tour 
        /// </summary>
        /// <param name="tourId">The tour id</param>
        /// <returns></returns>
        Task<List<BookingEntity>> GetAll(int tourId);
    }
}