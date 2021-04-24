﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Service.Model.TourManager;

namespace TourManager.Service.Abstraction
{
    /// <summary>
    /// The bookings service interface
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Get bookings
        /// </summary>
        /// <param name="agencyId">The agency id</param>
        /// <returns></returns>
        public Task<List<BookingResponseModel>> GetBookings(int agencyId, int? tourId, DateTime? cancellationDeadlineFrom);

        /// <summary>
        /// Get specific booking by id 
        /// </summary>
        /// <param name="bookingId">The booking id</param>
        /// <returns></returns>
        public Task<BookingResponseModel> GetBookingById(int bookingId);

        /// <summary>
        /// Create new booking
        /// </summary>
        /// <param name="booking">The booking to create</param>
        /// <returns></returns>
        public Task CreateBooking(AddEditBookingRequestModel booking);

        /// <summary>
        /// Create several booking
        /// </summary>
        /// <param name="bookings">Booking list to create</param>
        /// <returns></returns>
        Task CreateBookings(int tourId, IEnumerable<AddEditBookingRequestModel> bookings);

        /// <summary>
        /// Cancel a specific booking by id
        /// </summary>
        /// <param name="bookingId">The booking id to cancel</param>
        /// <returns></returns>
        public Task CancelBooking(int bookingId);

        /// <summary>
        /// Update a specific booking 
        /// </summary>
        /// <param name="booking">The booking to update</param>
        /// <returns></returns>
        public Task UpdateBooking(AddEditBookingRequestModel booking);
    }
}