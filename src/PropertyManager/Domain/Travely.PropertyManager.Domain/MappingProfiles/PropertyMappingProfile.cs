using AutoMapper;
using Travely.PropertyManager.Domain.Models.Commands;
using Travely.PropertyManager.Domain.Models.Responses;
using Travely.PropertyManager.Domain.Entities;

namespace Travely.PropertyManager.Domain.MappingProfiles
{
    public class PropertyMappingProfile : Profile
    {
        public PropertyMappingProfile()
        {
            CreateMap<AddPropertyCommand, Property>();
            CreateMap<Property, PropertyResponse>();
        }
    }
}
