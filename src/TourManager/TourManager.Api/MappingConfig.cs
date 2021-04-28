using AutoMapper;
using System.Linq;
using TourManager.Repository.Entities;
using TourManager.Service.Model;
using TourManager.Service.Model.TourManager;

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
            this.CreateMap<Booking, BookingEntity>().ReverseMap();
            this.CreateMap<BookingProperty, BookingPropertyEntity>().ReverseMap();
            this.CreateMap<BookingService, BookingServiceEntity>().ReverseMap();

            // tour mappings
            this.CreateMap<Tour, TourEntity>()
                   .ForMember(dest => dest.Bookings, opt => opt.Ignore())
                   .ForMember(dest => dest.TourClients, opt => opt.Ignore());
            this.CreateMap<TourEntity, Tour>()
                .ForMember(dest => dest.Clients, opt => opt.MapFrom(src => src.TourClients.Select(tc => tc.Client)));
        }
    }
}
