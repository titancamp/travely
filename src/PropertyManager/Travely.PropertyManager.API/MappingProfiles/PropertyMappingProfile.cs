using AutoMapper;
using Google.Protobuf.Collections;
using System.Collections.Generic;
using Travely.PropertyManager.API.MappingProfiles.Converters;
using Travely.PropertyManager.Grpc;
using Travely.PropertyManager.Service.Models.Commands;
using Travely.PropertyManager.Service.Models.Queries;
using Travely.PropertyManager.Service.Models.Responses;

namespace Travely.PropertyManager.API.MappingProfiles
{
    public class PropertyMappingProfile : Profile
    {
        public PropertyMappingProfile()
        {
            CreateMap(typeof(RepeatedField<>), typeof(ICollection<>)).ConvertUsing(typeof(RepeatedFieldToCollectionConverter<,>));

            CreateMap<OrderingBaseModel, Service.Models.Base.OrderingBaseModel>();
            CreateMap<FilteringBaseModel, Service.Models.Base.FilteringBaseModel>();

            CreateMap<PropertyAttachment, PropertyAttachmentModel>().ReverseMap();
            CreateMap<AddPropertyRequest, AddPropertyCommand>();
            CreateMap<EditPropertyRequest, EditPropertyCommand>();

            CreateMap<PropertyResponse, GetPropertyByIdResponse>();

            CreateMap<GetPropertiesRequest, GetPropertiesQuery>();
            CreateMap<PropertyResponse, GetPropertiesResponse>();
        }
    }
}
