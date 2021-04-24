using System.Linq;
using AutoMapper;
using TourManager.Repository.Entities;
using TourManager.Service.Model;
using TourManager.Service.Model.PropertyManager;
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
            CreateMap<Client, ClientEntity>();
            CreateMap<ClientEntity, Client>();

            // TourClient mappings
            CreateMap<Client, ClientEntity>();

            CreateMap<Client, TourClientEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src));

            // Property Mappings
            CreateMap<AddEditPropertyRequestModel, PropertyEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.AgencyId, opt => opt.Ignore());

            // booking mappings
            CreateMap<AddEditBookingRequestModel, BookingEntity>();
            CreateMap<BookingEntity, BookingResponseModel>();
            CreateMap<PropertyEntity, PropertyModel>().ReverseMap();
            CreateMap<BookingPropertyModel, BookingPropertyEntity>().ReverseMap();
            CreateMap<BookingPropertyRoomModel, BookingPropertyRoomEntity>().ReverseMap();
            CreateMap<BookingPropertyRoomGuestModel, BookingPropertyRoomGuestEntity>().ReverseMap();
            CreateMap<BookingServiceModel, BookingServiceEntity>().ReverseMap();
            CreateMap<BookingTransportationModel, BookingTransportationEntity>().ReverseMap();

            // tour mappings
            CreateMap<AddEditTourRequestModel, TourEntity>()
                   .ForMember(dest => dest.TourClients, opt => opt.MapFrom(src =>
                        src.ClientIds.Select(item => new TourClientEntity { ClientId = item }).ToList()))
                   .ForMember(dest => dest.Bookings, opt => opt.Ignore());
            CreateMap<TourEntity, TourResponseModel>();
        }
    }
}
