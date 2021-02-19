using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Repository.Abstraction;
using TourManager.Repository.Entities;
using TourManager.Service.Abstraction;
using TourManager.Service.Model;

namespace TourManager.Service.Implementation
{
    public class TourService : ITourService
    {
        private readonly IMapper mapper;
        private readonly ITourRepository tourRepository;
        private readonly IBookingService bookingService;
        private readonly IClientService clientService;

        public TourService(IMapper mapper, ITourRepository tourRepository, IBookingService bookingService, IClientService clientService)
        {
            this.mapper = mapper;
            this.tourRepository = tourRepository;
            this.bookingService = bookingService;
            this.clientService = clientService;
        }

        public async Task<List<Tour>> GetTours(int tenantId)
        {
            var result = await this.tourRepository.GetAll();

            return this.mapper.Map<List<Tour>>(result);
        }

        public async Task<Tour> GetTourById(int tenantId, int tourId)
        {
            var result = await this.tourRepository.GetById(tourId);

            return this.mapper.Map<Tour>(result);
        }

        public Task<Tour> CreateTour(int tenantId, Tour tour)
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
            this.tourRepository.Add(this.mapper.Map<TourEntity>(tour));

            throw new NotImplementedException();
        }

        public Task<Tour> UpdateTour(int tenantId, int id, Tour tour)
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

        public async Task RemoveTour(int tenantId, int tourId)
        {
            // find tour to remove by id
            var tour = await this.tourRepository.GetById(tourId);

            // remove found tour
            await this.tourRepository.Remove(tour);
        }
    }
}