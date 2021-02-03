using AutoMapper;
using Travely.PropertyManager.Domain.Contracts.Models.Commands;
using Travely.PropertyManager.Domain.Contracts.Models.Queries;
using Travely.PropertyManager.Domain.Contracts.Models.Responses;
using Travely.PropertyManager.GrpcService.Contracts;

namespace Travely.PropertyManager.GrpcService.MappingProfiles
{
    public class PropertyTypeMappingProfile : Profile
    {
        public PropertyTypeMappingProfile()
        {
           CreateMap<AddPropertyTypeRequest, AddPropertyTypeCommand>();
           CreateMap<GetPropertyTypesRequest, GetPropertyTypesQuery>();

           CreateMap<PropertyTypeResponse, GetPropertyTypeResponse>();
        }
    }
}
