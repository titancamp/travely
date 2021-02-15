using AutoMapper;
using Travely.PropertyManager.Service.Models.Commands;
using Travely.PropertyManager.Data.Models;
using Travely.PropertyManager.Service.Models.Responses;

namespace Travely.PropertyManager.Service.MappingProfiles
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
