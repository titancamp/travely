using AutoMapper;
using Travely.PropertyManager.Domain.Contracts.Models.Responses;
using Travely.PropertyManager.Domain.Entities;

namespace Travely.PropertyManager.Domain.MappingProfiles
{
    public class PropertyMappingProfile : Profile
    {
        public PropertyMappingProfile()
        {
            CreateMap<Property, PropertyResponse>();
        }
    }
}
