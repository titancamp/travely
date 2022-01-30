using AutoMapper;
using System.Linq;
using TourManager.Repository.Entities;
using TourManager.Service.Model;
using TourManager.Service.Model.TourManager;
using Travely.ClientManager.Grpc.Models;

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
            CreateMap<Client, ClientEntity>();
            CreateMap<ClientEntity, Client>();

            // TourClient mappings
            CreateMap<Client, ClientEntity>();

            CreateMap<Client, TourClientEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src));

            // booking mappings
            CreateMap<Booking, BookingEntity>();
            CreateMap<BookingEntity, Booking>()
                .ForMember(dest => dest.TourName, opt => opt.MapFrom(src => src.Tour != null ? src.Tour.Name : null));
            CreateMap<BookingProperty, BookingPropertyEntity>().ReverseMap();
            CreateMap<BookingService, BookingServiceEntity>().ReverseMap();

            // tour mappings
            CreateMap<Tour, TourEntity>()
                   .ForMember(dest => dest.Bookings, opt => opt.Ignore())
                   .ForMember(dest => dest.TourClients, opt => opt.Ignore());
            CreateMap<TourEntity, Tour>()
                .ForMember(dest => dest.Clients, opt => opt.MapFrom(src => src.TourClients.Select(tc => tc.Client).ToList()));
        }
    }
}
