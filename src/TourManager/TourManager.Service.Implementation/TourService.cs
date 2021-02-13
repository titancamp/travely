using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Repository.Abstraction;
using TourManager.Service.Abstraction;
using TourManager.Service.Implementation.Mappers;
using TourManager.Service.Model;

namespace TourManager.Service.Implementation
{
    /// <summary>
    /// The tour service
    /// </summary>
    public class TourService : ITourService
    {
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
        /// <param name="tourRepository">The tour repository</param>
        public TourService(ITourRepository tourRepository, IBookingService bookingService, IClientService clientService)
        {
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

            return TourMapper.MapFrom(result);
        }

        /// <summary>
        /// Get specific tour by id 
        /// </summary>
        /// <param name="tourId">The tour id</param>
        /// <returns></returns>
        public async Task<Tour> GetTourById(int tourId)
        {
            var result = await this.tourRepository.GetById(tourId);

            return TourMapper.MapFromSingle(result);
        }

        /// <summary>
        /// Create new tour
        /// </summary>
        /// <param name="tour">The tour to create</param>
        /// <returns></returns>
        public async Task CreateTour(Tour tour)
        {
            // create clients
            foreach (var client in tour.Clients)
            {
                await this.clientService.CreateClient(client);
            }

            // create bookings
            foreach (var booking in tour.Bookings)
            {
                await this.bookingService.CreateBooking(booking);
            }

            // create tour
            await this.tourRepository.Add(TourMapper.MapToSingle(tour));
        }

        /// <summary>
        /// Update the specific tour
        /// </summary>
        /// <param name="tour">The tour to update</param>
        /// <returns></returns>
        public async Task UpdateTour(Tour tour)
        {
            // update clients
            foreach (var client in tour.Clients)
            {
                await this.clientService.UpdateClient(client);
            }

            // update bookings
            foreach (var booking in tour.Bookings)
            {
                await this.bookingService.UpdateBooking(booking);
            }

            // update tour
            await this.tourRepository.Update(TourMapper.MapToSingle(tour));
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