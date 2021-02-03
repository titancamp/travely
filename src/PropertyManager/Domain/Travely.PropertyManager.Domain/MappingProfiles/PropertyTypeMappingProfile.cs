using AutoMapper;
using Travely.PropertyManager.Domain.Contracts.Models.Commands;
using Travely.PropertyManager.Domain.Contracts.Models.Responses;
using Travely.PropertyManager.Domain.Entities;

namespace Travely.PropertyManager.Domain.MappingProfiles
{
    public class PropertyTypeMappingProfile : Profile
    {
        public PropertyTypeMappingProfile()
        {
            CreateMap<AddPropertyTypeCommand, PropertyType>();
           
            CreateMap<PropertyType, PropertyTypeResponse>();
        }
    }

}
