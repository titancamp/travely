using AutoMapper;
using TourManager.Common.Clients.PropertyManager;
using Travely.PropertyManager.API;

namespace TourManager.Clients.Implementation.Mappers
{
    public class PropertyClientProfile : Profile
    {
        public PropertyClientProfile()
        {
            CreateMap<Common.Clients.PropertyManager.PropertyAttachment, Travely.PropertyManager.API.PropertyAttachment>()
                .ReverseMap();
            CreateMap<Common.Clients.PropertyManager.AddPropertyRequest, Travely.PropertyManager.API.AddPropertyRequest>()
                .ForMember(dest => dest.Attachments, opt => opt.MapFrom(src => src.Attachments));
            CreateMap<GetPropertyByIdResponse, PropertyResponse>();
            CreateMap<GetPropertiesResponse, PropertyResponse>();
        }
    }
}
