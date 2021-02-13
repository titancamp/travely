using System;
using System.Collections.Generic;
using System.Linq;
using TourManager.Common.Extend;
using TourManager.Common.Types;
using TourManager.Repository.Entities;
using TourManager.Service.Model;

namespace TourManager.Service.Implementation.Mappers
{
    /// <summary>
    /// Booking mapper
    /// </summary>
    public class BookingMapper
    {
        /// <summary>
        /// Map booking single entity to booking model
        /// </summary>
        /// <param name="booking">The booking entity to map</param>
        /// <returns></returns>
        public static Booking MapFromSingle(BookingEntity booking)
        {
            return new Booking
            {
                Id = booking.Id,
                Name = booking.Name,
                Type = booking.Type.ToEnum(BookingType.None),
                Status = booking.Status.ToEnum(BookingStatus.None),
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                CancellationDeadline = booking.CancellationDeadline,
                Origin = booking.Origin,
                ArrivalTime = booking.ArrivalTime,
                ArrivalFlightNumber = booking.ArrivalFlightNumber,
                DepartureTime = booking.DepartureTime,
                DepartureFlightNumber = booking.DepartureFlightNumber,
                Notes = booking.Notes,
                Destinations = booking.Destinations.ToList()
            };
        }

        /// <summary>
        /// Map booking single model to booking entity
        /// </summary>
        /// <param name="booking">The booking model to map</param>
        /// <returns></returns>
        public static BookingEntity MapToSingle(Booking booking)
        {
            return new BookingEntity
            {
                Id = booking.Id,
                Name = booking.Name,
                Type = booking.Type.ToString(),
                Status = booking.Status.ToString(),
                CheckInDate = booking.CheckInDate ?? new DateTime(),
                CheckOutDate = booking.CheckOutDate ?? new DateTime(),
                CancellationDeadline = booking.CancellationDeadline ?? new DateTime(),
                Origin = booking.Origin,
                ArrivalTime = booking.ArrivalTime ?? new DateTime(),
                ArrivalFlightNumber = booking.ArrivalFlightNumber,
                DepartureTime = booking.DepartureTime ?? new DateTime(),
                DepartureFlightNumber = booking.DepartureFlightNumber,
                Notes = booking.Notes,
                Destinations = booking.Destinations
            };
        }

        /// <summary>
        /// Map booking entities collection to booking model collection
        /// </summary>
        /// <param name="bookings">The bookings collection to map</param>
        /// <returns></returns>
        public static List<Booking> MapFrom(ICollection<BookingEntity> bookings)
        {
            var result = new List<Booking>();

            foreach (var booking in bookings)
            {
                // map each booking
                result.Add(MapFromSingle(booking));
            }

            return result;
        }

        /// <summary>
        /// Map booking models collection to booking entities collection
        /// </summary>
        /// <param name="bookings">The bookings collection to map</param>
        /// <returns></returns>
        public static List<BookingEntity> MapTo(ICollection<Booking> bookings)
        {
            var result = new List<BookingEntity>();

            foreach (var booking in bookings)
            {
                // map each booking
                result.Add(MapToSingle(booking));
            }

            return result;
        }
    }
}
