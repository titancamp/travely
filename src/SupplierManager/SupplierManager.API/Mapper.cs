using AutoMapper;
using SupplierManager.API.Requests;
using SupplierManager.API.Responses;
using SupplierManager.Service.Models;

namespace SupplierManager.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AccommodationRequest, Accommodation>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Accommodation, AccommodationResponse>();
        }
    }
}