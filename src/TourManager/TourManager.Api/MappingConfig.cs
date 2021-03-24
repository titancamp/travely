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

            // TourClient mappings
            this.CreateMap<Client, ClientEntity>();

            this.CreateMap<Client, TourClientEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src));

            // booking mappings
            this.CreateMap<Booking, BookingEntity>();
            this.CreateMap<BookingEntity, Booking>();

            // tour mappings
            this.CreateMap<Tour, TourEntity>()
                   .ForMember(dest => dest.Bookings, opt => opt.Ignore())
                   .ForMember(dest => dest.TourClients, opt => opt.Ignore());
            this.CreateMap<TourEntity, Tour>();
        }
    }
}
