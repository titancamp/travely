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
            this.CreateMap<List<ClientEntity>, List<Client>>();

            // booking mappings
            this.CreateMap<Booking, BookingEntity>();
            this.CreateMap<BookingEntity, Booking>();
            this.CreateMap<List<BookingEntity>, List<Booking>>();

            // tour mappings
            this.CreateMap<Tour, TourEntity>().ForMember(dest => dest.Description, act => act.MapFrom(src => src.Notes));
            this.CreateMap<TourEntity, Tour>().ForMember(dest => dest.Notes, act => act.MapFrom(src => src.Description));
            this.CreateMap<List<TourEntity>, List<Tour>>();
        }
    }
}
