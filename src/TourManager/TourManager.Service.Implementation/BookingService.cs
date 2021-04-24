using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TourManager.Common.Types;
using TourManager.Repository.Abstraction;
using TourManager.Repository.Entities;
using TourManager.Repository.Models;
using TourManager.Service.Abstraction;
using TourManager.Service.Model.TourManager;

namespace TourManager.Service.Implementation
{
    /// <summary>
    /// The bookings service interface
    /// </summary>
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;
        private readonly IPropertyRepository _propertyRepository;

        /// <summary>
        /// Create new instance of booking service
        /// </summary>
        /// <param name="mapper">The model mapper</param>
        /// <param name="bookingRepository">The booking repository</param>
        /// <param name="propertyRepository">The property repository</param>
        public BookingService(
            IMapper mapper,
            IBookingRepository bookingRepository,
            IPropertyRepository propertyRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
            _propertyRepository = propertyRepository;
        }

        /// <summary>
        /// Get bookings
        /// </summary>
        /// <param name="agencyId">The agency id</param>
        /// <returns></returns>
        public async Task<List<BookingResponseModel>> GetBookings(int agencyId, int? tourId, DateTime? cancellationDeadlineFrom)
        {
            var filter = new GetBookingFilter
            {
                AgencyId = agencyId,
                TourId = tourId,
                CancellationDeadlineFrom = cancellationDeadlineFrom
            };

            var result = await _bookingRepository.Get(filter);

            return _mapper.Map<List<BookingResponseModel>>(result);
        }

        /// <summary>
        /// Get specific booking by id 
        /// </summary>
        /// <param name="bookingId">The booking id</param>
        /// <returns></returns>
        public async Task<BookingResponseModel> GetBookingById(int bookingId)
        {
            var result = await _bookingRepository.GetById(bookingId);

            return _mapper.Map<BookingResponseModel>(result);
        }

        /// <summary>
        /// Create new booking
        /// </summary>
        /// <param name="booking">The booking to create</param>
        /// <returns></returns>
        public Task CreateBooking(AddEditBookingRequestModel booking)
        {
            return _bookingRepository.Add(_mapper.Map<BookingEntity>(booking));
        }

        /// <summary>
        /// Create several booking
        /// </summary>
        /// <param name="bookings">Booking list to create</param>
        /// <returns></returns>
        public async Task CreateBookings(int tourId, IEnumerable<AddEditBookingRequestModel> bookings)
        {
            var entities = _mapper.Map<IEnumerable<BookingEntity>>(bookings).ToList();

            var propertyIds = entities.Where(item => item.BookingProperty != null)
                .Select(item => item.BookingProperty.PropertyId).ToList();

            var properties = await _propertyRepository.GetAll();
            var propertiesFound = properties.Where(item => propertyIds.Contains(item.Id)).Count();

            if (propertiesFound < propertyIds.Count)
            {
                throw new Exception("Hotel not found");
            }

            entities.ForEach(x => x.TourId = tourId);

            await _bookingRepository.AddRange(entities);
        }

        /// <summary>
        /// Cancel a specific booking by id
        /// </summary>
        /// <param name="bookingId">The booking id to cancel</param>
        /// <returns></returns>
        public async Task CancelBooking(int bookingId)
        {
            var booking = await _bookingRepository.GetById(bookingId);

            booking.Status = (int)BookingStatus.Cancelled;

            await _bookingRepository.Update(booking);
        }

        /// <summary>
        /// Update a specific booking 
        /// </summary>
        /// <param name="booking">The booking to update</param>
        /// <returns></returns>
        public Task UpdateBooking(AddEditBookingRequestModel booking)
        {
            return _bookingRepository.Update(_mapper.Map<BookingEntity>(booking));
        }
    }
}