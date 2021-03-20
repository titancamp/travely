using AutoMapper;
using System.Collections.Generic;
using TourManager.Repository.Entities;
using TourManager.Service.Model;

namespace TourManager.Api
{
    /// <summary>
    /// Model for model mapping configurations
    /// </summary>
    public class MappingConfig : Profile
    {
        /// <summary>
        /// Create new instance of mapping configuration
        /// </summary>
        public MappingConfig()
        {
            // client mappings
            this.CreateMap<Client, ClientEntity>();
            this.CreateMap<ClientEntity, Client>();

            // booking mappings
            this.CreateMap<Booking, BookingEntity>();
            this.CreateMap<BookingEntity, Booking>();

            // tour mappings
            this.CreateMap<Tour, TourEntity>();
            this.CreateMap<TourEntity, Tour>();
        }
    }
}
