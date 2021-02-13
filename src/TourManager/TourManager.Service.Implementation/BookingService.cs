using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Common.Types;
using TourManager.Repository.Abstraction;
using TourManager.Service.Abstraction;
using TourManager.Service.Implementation.Mappers;
using TourManager.Service.Model;

namespace TourManager.Service.Implementation
{
    /// <summary>
    /// The bookings service interface
    /// </summary>
    public class BookingService : IBookingService
    {
        /// <summary>
        /// The booking repository
        /// </summary>
        private readonly IBookingRepository bookingRepository;

        /// <summary>
        ///  Create new instance of booking service
        /// </summary>
        /// <param name="bookingRepository">The booking repository</param>
        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        /// <summary>
        /// Get the bookings of a tour
        /// </summary>
        /// <param name="tourId">The tour id</param>
        /// <returns></returns>
        public async Task<List<Booking>> GetBookings(int tourId)
        {
            var result = await this.bookingRepository.GetAll(tourId);

            return BookingMapper.MapFrom(result);
        }

        /// <summary>
        /// Get specific booking by id 
        /// </summary>
        /// <param name="bookingId">The booking id</param>
        /// <returns></returns>
        public async Task<Booking> GetBookingById(int bookingId)
        {
            var result = await this.bookingRepository.GetById(bookingId);

            return BookingMapper.MapFromSingle(result);
        }

        /// <summary>
        /// Create new booking
        /// </summary>
        /// <param name="booking">The booking to create</param>
        /// <returns></returns>
        public async Task CreateBooking(Booking booking)
        {
            await this.bookingRepository.Add(BookingMapper.MapToSingle(booking));
        }

        /// <summary>
        /// Cancel a specific booking by id
        /// </summary>
        /// <param name="bookingId">The booking id to cancel</param>
        /// <returns></returns>
        public async Task CancelBooking(int bookingId)
        {
            // get and map booking to cancel
            var booking = await this.GetBookingById(bookingId);

            // set cancellation status
            booking.Status = BookingStatus.Cancelled;

            // update booking
            await this.UpdateBooking(booking);
        }

        /// <summary>
        /// Update a specific booking 
        /// </summary>
        /// <param name="booking">The booking to update</param>
        /// <returns></returns>
        public async Task UpdateBooking(Booking booking)
        {
            await this.bookingRepository.Update(BookingMapper.MapToSingle(booking));
        }
    }
}