using System;
using System.Collections.Generic;
using System.Linq;
using TourManager.Repository.Entities;
using TourManager.Service.Model;

namespace TourManager.Service.Implementation.Mappers
{
    /// <summary>
    /// Tour mapper
    /// </summary>
    public class TourMapper
    {
        /// <summary>
        /// Map tour entity to tour model
        /// </summary>
        /// <param name="tour">The tour to map</param>
        /// <returns></returns>
        public static Tour MapFromSingle(TourEntity tour)
        {
            return new Tour
            {
                Id = tour.Id,
                TenantId = tour.TenantId,
                IsPackage = tour.IsPackage,
                Name = tour.Name,
                Price = tour.Price,
                Origin = tour.Origin,
                StartDate = tour.StartDate,
                EndDate = tour.EndDate,
                PickUpTime = tour.PickUpTime,
                PickUpDetails = tour.PickUpDetails,
                DropOffTime = tour.DropOffTime,
                DropOffDetails = tour.DropOffDetails,
                Notes = tour.Description,
                Destinations = tour.Destinations.ToList(),
                Bookings = BookingMapper.MapFrom(tour.Bookings),
                Clients = ClientMapper.MapFrom(tour.TourClients)
            };
        }

        /// <summary>
        /// Map tour model to tour entity
        /// </summary>
        /// <param name="tour">The tour to map</param>
        /// <returns></returns>
        public static TourEntity MapToSingle(Tour tour)
        {
            return new TourEntity
            {
                Id = tour.Id,
                TenantId = tour.TenantId,
                IsPackage = tour.IsPackage ?? false,
                Name = tour.Name,
                Price = tour.Price,
                Origin = tour.Origin,
                StartDate = tour.StartDate ?? new DateTime(),
                EndDate = tour.EndDate ?? new DateTime(),
                PickUpTime = tour.PickUpTime ?? new DateTime(),
                PickUpDetails = tour.PickUpDetails,
                DropOffTime = tour.DropOffTime ?? new DateTime(),
                DropOffDetails = tour.DropOffDetails,
                Description = tour.Notes,
                Destinations = tour.Destinations.ToList(),
                Bookings = BookingMapper.MapTo(tour.Bookings),
                TourClients = ClientMapper.MapTo(tour.Clients)
            };
        }

        /// <summary>
        /// Map tour entities collection to tour model collection
        /// </summary>
        /// <param name="tours">The tours collection to map</param>
        /// <returns></returns>
        public static List<Tour> MapFrom(ICollection<TourEntity> tours)
        {
            var result = new List<Tour>();

            foreach (var tour in tours)
            {
                // map each tour
                result.Add(MapFromSingle(tour));
            }

            return result;
        }

        /// <summary>
        /// Map tour models collection to tour entities collection
        /// </summary>
        /// <param name="tours">The tours collection to map</param>
        /// <returns></returns>
        public static List<TourEntity> MapTo(ICollection<Tour> tours)
        {
            var result = new List<TourEntity>();

            foreach (var tour in tours)
            {
                // map each tour
                result.Add(MapToSingle(tour));
            }

            return result;
        }
    }
}
