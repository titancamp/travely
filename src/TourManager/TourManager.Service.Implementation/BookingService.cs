using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Common.Types;
using TourManager.Repository.Abstraction;
using TourManager.Repository.Entities;
using TourManager.Service.Abstraction;
using TourManager.Service.Model;

namespace TourManager.Service.Implementation
{
    /// <summary>
    /// The bookings service interface
    /// </summary>
    public class BookingService : IBookingService
    {
        /// <summary>
        /// The model mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The booking repository
        /// </summary>
        private readonly IBookingRepository bookingRepository;

        /// <summary>
        /// Create new instance of booking service
        /// </summary>
        /// <param name="mapper">The model mapper</param>
        /// <param name="bookingRepository">The booking repository</param>
        public BookingService(IMapper mapper, IBookingRepository bookingRepository)
        {
            this.mapper = mapper;
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

            return this.mapper.Map<List<Booking>>(result);
        }

        /// <summary>
        /// Get specific booking by id 
        /// </summary>
        /// <param name="bookingId">The booking id</param>
        /// <returns></returns>
        public async Task<Booking> GetBookingById(int bookingId)
        {
            var result = await this.bookingRepository.GetById(bookingId);

            return this.mapper.Map<Booking>(result);
        }

        /// <summary>
        /// Create new booking
        /// </summary>
        /// <param name="booking">The booking to create</param>
        /// <returns></returns>
        public Task CreateBooking(Booking booking)
        {
            return this.bookingRepository.Add(this.mapper.Map<BookingEntity>(booking));
        }

        /// <summary>
        /// Cancel a specific booking by id
        /// </summary>
        /// <param name="bookingId">The booking id to cancel</param>
        /// <returns></returns>
        public Task CancelBooking(int bookingId)
        {
            // get and map booking to cancel
            var booking = this.GetBookingById(bookingId);

            // set cancellation status
            booking.Result.Status = BookingStatus.Cancelled;

            // update booking
            return this.UpdateBooking(booking.Result);
        }

        /// <summary>
        /// Update a specific booking 
        /// </summary>
        /// <param name="booking">The booking to update</param>
        /// <returns></returns>
        public Task UpdateBooking(Booking booking)
        {
            return this.bookingRepository.Update(this.mapper.Map<BookingEntity>(booking));
        }
    }
}