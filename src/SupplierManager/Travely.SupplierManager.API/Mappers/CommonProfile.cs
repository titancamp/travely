using AutoMapper;
using Travely.SupplierManager.API.Models;
using Travely.SupplierManager.API.Responses;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Mappers
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<Location, LocationEntity>().ReverseMap();
            CreateMap<SupplierQueryParamsResponse, SupplierQueryParams>();
            CreateMap(typeof(SupplierPage<>), typeof(SupplierPageResponse<>));
        }
    }
}