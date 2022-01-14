using AutoMapper;
using Travely.SupplierManager.API.Models;
using Travely.SupplierManager.API.Requests;
using Travely.SupplierManager.API.Responses;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Mappers
{
    public class AccommodationProfile : Profile
    {
        public AccommodationProfile()
        {
            CreateMap<Accommodation, AccommodationEntity>().ForMember(x => x.Id, opt => opt.Ignore());
            
            CreateMap<AccommodationService, AccommodationServiceEntity>();
            CreateMap<AccommodationServiceEntity, AccommodationService>();

            CreateMap<Room, RoomEntity>();
            CreateMap<RoomEntity, Room>();
            
            CreateMap<RoomType, RoomTypeEntity>();
            CreateMap<RoomTypeEntity, RoomType>();
            
            CreateMap<RoomService, RoomServiceEntity>();
            CreateMap<RoomServiceEntity, RoomService>();
            
            CreateMap<AccommodationEntity, Accommodation>();
            
            CreateMap<Accommodation, AccommodationResponse>()
                .ForPath(dst => dst.Type, opt => opt.MapFrom(src => src.Type.Name));

            CreateMap<AccommodationRequest, Accommodation>()
                .ForPath(x => x.Type.Id, e => e.MapFrom(src => src.Type));

            CreateMap<AccommodationTypeEntity, AccommodationType>();
            CreateMap<AccommodationType, AccommodationTypeEntity>();

            CreateMap<SupplierQueryParamsResponse, SupplierQueryParams>();
            CreateMap(typeof(SupplierPage<>), typeof(SupplierPageResponse<>));
        }
    }
}