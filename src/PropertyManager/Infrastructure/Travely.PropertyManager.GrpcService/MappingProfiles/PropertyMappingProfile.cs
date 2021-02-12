using AutoMapper;
using System;
using System.Globalization;
using Travely.PropertyManager.Domain.Models.Commands;
using Travely.PropertyManager.Domain.Models.Queries;
using Travely.PropertyManager.Domain.Models.Responses;
using Travely.PropertyManager.GrpcService.Contracts;

namespace Travely.PropertyManager.GrpcService.MappingProfiles
{
    public class PropertyMappingProfile : Profile
    {
        public PropertyMappingProfile()
        {
            CreateMap<AddPropertyRequest, AddPropertyCommand>()
                .ForMember(dest => dest.Latitude, src => src.MapFrom(i => string.IsNullOrEmpty(i.Latitude) ? (decimal?)null : decimal.Parse(i.Latitude, CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Longitude, src => src.MapFrom(i => string.IsNullOrEmpty(i.Longitude) ? (decimal?)null : decimal.Parse(i.Longitude, CultureInfo.InvariantCulture)));
             
            CreateMap<GetPropertiesRequest, GetPropertiesQuery>();

            CreateMap<PropertyResponse, GetPropertiesResponse>()
                .ForMember(dest => dest.Latitude, src => src.MapFrom(i => i.Latitude.ToString()))
                .ForMember(dest => dest.Longitude, src => src.MapFrom(i => i.Longitude.ToString()));
        }
    }
}
