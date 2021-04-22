using AutoMapper;
using TourManager.Service.Model.PropertyManager;
using Travely.PropertyManager.API;

namespace TourManager.Clients.Implementation.Mappers
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

            CreateMap<GetRoomTypesResponse, RoomTypeResponseModel>();
        }
    }
}
