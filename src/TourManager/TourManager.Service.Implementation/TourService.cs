using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Repository.Abstraction;
using TourManager.Repository.Entities;
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
        public TourService(IMapper mapper, ITourRepository tourRepository, IBookingService bookingService, IClientService clientService)
        {
            this.mapper = mapper;
            this.tourRepository = tourRepository;
            this.bookingService = bookingService;
            this.clientService = clientService;
        }

        /// <summary>
        /// Get tour by tenant id
        /// </summary>
        /// <param name="tenantId">The tenant id</param>
        /// <returns></returns>
        public async Task<List<Tour>> GetTours(int tenantId)
        {
            var result = await this.tourRepository.GetAll();

            return this.mapper.Map<List<Tour>>(result);
        }

        /// <summary>
        /// Get specific tour by id 
        /// </summary>
        /// <param name="tourId">The tour id</param>
        /// <returns></returns>
        public async Task<Tour> GetTourById(int tourId)
        {
            var result = await this.tourRepository.GetById(tourId);

            return this.mapper.Map<Tour>(result);
        }

        /// <summary>
        /// Create new tour
        /// </summary>
        /// <param name="tour">The tour to create</param>
        /// <returns></returns>
        public Task CreateTour(Tour tour)
        {
            // create clients
            foreach (var client in tour.Clients)
            {
                this.clientService.CreateClient(client);
            }

            // create bookings
            foreach (var booking in tour.Bookings)
            {
                this.bookingService.CreateBooking(booking);
            }

            // create tour
            return this.tourRepository.Add(this.mapper.Map<TourEntity>(tour));
        }

        /// <summary>
        /// Update the specific tour
        /// </summary>
        /// <param name="tour">The tour to update</param>
        /// <returns></returns>
        public Task UpdateTour(Tour tour)
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
            return this.tourRepository.Update(this.mapper.Map<TourEntity>(tour));
        }

        /// <summary>
        /// Remove specific tour by id
        /// </summary>
        /// <param name="tourId">The tour id to remove</param>
        /// <returns></returns>
        public async Task RemoveTour(int tourId)
        {
            // find tour to remove by id
            var tour = await this.tourRepository.GetById(tourId);

            // remove found tour
            await this.tourRepository.Remove(tour);
        }
    }
}