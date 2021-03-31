using AutoMapper;
using TourManager.Common.Clients.PropertyManager;
using Travely.PropertyManager.API;

namespace TourManager.Clients.Implementation.Mappers
{
    public class PropertyClientProfile : Profile
    {
        public PropertyClientProfile()
        {
            CreateMap<PropertyAttachmentDto, PropertyAttachment>()
                .ReverseMap();
            CreateMap<AddPropertyRequestDto, AddPropertyRequest>();
            CreateMap<EditPropertyRequestDto, EditPropertyRequest>()
                .ForMember(dest => dest.Attachments, opt => opt.MapFrom(src => src.Attachments));
            CreateMap<GetPropertyByIdResponse, PropertyResponseDto>();
            CreateMap<GetPropertiesResponse, PropertyResponseDto>();
        }
    }
}
