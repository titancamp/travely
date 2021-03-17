using AutoMapper;
using Travely.PropertyManager.API;
using TourManager.Common.Clients.PropertyManager;

namespace TourManager.Clients.Implementation.Mappers
{
    public class PropertyClientProfile : Profile
    {
        public PropertyClientProfile()
        {
            CreateMap<TourManager.Common.Clients.PropertyManager.AddPropertyRequest, Travely.PropertyManager.API.AddPropertyRequest>();
            CreateMap<GetPropertiesResponse, PropertyResponse>();
        }
    }
}
