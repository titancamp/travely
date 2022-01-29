using AutoMapper;
using Travely.PropertyManager.Grpc.Models;

namespace Travely.PropertyManager.Grpc.Mapper
{
    public class PropertyClientProfile : Profile
    {
        public PropertyClientProfile()
        {
            CreateMap<PropertyAttachmentModel, PropertyAttachment>()
                .ReverseMap();
            CreateMap<AddEditPropertyRequestModel, AddPropertyRequest>();
            CreateMap<AddEditPropertyRequestModel, EditPropertyRequest>()
                .ForMember(dest => dest.Attachments, opt => opt.MapFrom(src => src.Attachments));
            CreateMap<GetPropertyByIdResponse, PropertyResponseModel>();
            CreateMap<GetPropertiesResponse, PropertyResponseModel>();
        }
    }
}
