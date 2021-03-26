using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TourManager.Repository.Abstraction;
using TourManager.Repository.Entities;
using TourManager.Repository.Models;
using TourManager.Service.Abstraction;
using TourManager.Service.Model;

namespace TourManager.Service.Implementation
{
    /// <summary>
    /// The tour service
    /// </summary>
    public class TourService : ITourService
    {
        /// <summary>
        /// The model mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The tour repository
        /// </summary>
        private readonly ITourRepository tourRepository;

        /// <summary>
        /// The booking service
        /// </summary>
        private readonly IBookingService bookingService;

        /// <summary>
        /// The client service
        /// </summary>
        private readonly IClientService clientService;

        /// <summary>
        ///  Create new instance of tour service
        /// </summary>
        /// <param name="mapper">The model mapper</param>
        /// <param name="tourRepository">The tour repository</param>
        /// <param name="bookingService">The booking service</param>
        /// <param name="clientService">The client service</param>
        public TourService(IMapper mapper,
            ITourRepository tourRepository,
            IBookingService bookingService,
            IClientService clientService)
        {
            this.mapper = mapper;
            this.tourRepository = tourRepository;
            this.bookingService = bookingService;
            this.clientService = clientService;
        }

        /// <summary>
        /// Get tours
        /// </summary>
        /// <param name="agencyId">The agency id</param>
        /// <param name="startDate">The agency id</param>
        /// <param name="endDate">The agency id</param>
        /// <returns></returns>
        public async Task<List<Tour>> GetTours(int agencyId, DateTime? startDate, DateTime? endDate)
        {
            var filter = new GetTourFilter()
            {
                AgencyId = agencyId,
                StartDate = startDate,
                EndDate = endDate
            };

            var result = await this.tourRepository.Get(filter);

            return this.mapper.Map<List<Tour>>(result);
        }

        /// <summary>
        /// Get specific tour by id
        /// </summary>
        /// <param name="tourId">The agency id</param>
        /// <returns></returns>
        public async Task<Tour> GetTourById(int agencyId, int tourId)
        {
            var result = await this.tourRepository.GetById(tourId);

            return this.mapper.Map<Tour>(result);
        }

        /// <summary>
        /// Create new tour
        /// </summary>
        /// <param name="tour">The tour to create</param>
        /// <returns></returns>
        public async Task<Tour> CreateTour(int agencyId, Tour tour)
        {
            var newTour = await this.tourRepository.Add(this.mapper.Map<TourEntity>(tour));

            await clientService.CreateClients(agencyId, newTour.Id, tour.Clients);

            await this.bookingService.CreateBookings(newTour.Id, tour.Bookings);

            return this.mapper.Map<Tour>(newTour);
        }

        /// <summary>
        /// Update the specific tour
        /// </summary>
        /// <param name="tour">The tour to update</param>
        /// <returns></returns>
        public Task<Tour> UpdateTour(int agencyId, int id, Tour tour)
        {
            // update clients
            foreach (var client in tour.Clients)
            {
                this.clientService.UpdateClient(client);
            }

            // update bookings
            foreach (var booking in tour.Bookings)
            {
                this.bookingService.UpdateBooking(booking);
            }

            // update tour
            this.tourRepository.Update(this.mapper.Map<TourEntity>(tour));

            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove specific tour by id
        /// </summary>
        /// <param name="tourId">The tour id to remove</param>
        /// <returns></returns>
        public async Task RemoveTour(int agencyId, int tourId)
        {
            // find tour to remove by id
            var tour = await this.tourRepository.GetById(tourId);

            // remove found tour
            await this.tourRepository.Remove(tour);
        }
    }
}