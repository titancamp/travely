using AutoMapper;
using Google.Protobuf.Collections;
using System.Collections.Generic;
using System.Globalization;
using Travely.PropertyManager.API.MappingProfiles.Converters;
using Travely.PropertyManager.API.Models;
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


            CreateMap<AddPropertyRequest, AddPropertyCommand>();

            CreateMap<GetPropertiesRequest, GetPropertiesQuery>();

            CreateMap<PropertyResponse, GetPropertiesResponse>()
                .ForMember(dest => dest.Latitude, src => src.MapFrom(i => i.Latitude.ToString()))
                .ForMember(dest => dest.Longitude, src => src.MapFrom(i => i.Longitude.ToString()));

            CreateMap<Travely.PropertyManager.API.Models.OrderingBaseModel, Travely.PropertyManager.Service.Models.Base.OrderingBaseModel>();
            CreateMap<Travely.PropertyManager.API.Models.FilteringBaseModel, Travely.PropertyManager.Service.Models.Base.FilteringBaseModel>();

        }
    }
}
