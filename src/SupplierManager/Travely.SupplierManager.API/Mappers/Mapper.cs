using AutoMapper;
using TourEntities.Service.Accommodation;
using TourEntities.Service.Accommodation.Room;
using TourEntities.Service.Common.Location;
using Travely.SupplierManager.API.Models;
using Travely.SupplierManager.API.Requests;
using Travely.SupplierManager.API.Responses;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Accommodation, AccommodationEntity>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Location, LocationEntity>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<LocationEntity, Location>();
            CreateMap<Room, RoomEntity>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<RoomEntity, Room>();
            CreateMap<string, AccommodationServiceEntity>();
            CreateMap<string, RoomServiceEntity>();
            CreateMap<string, AttachmentEntity>();
            CreateMap<AccommodationEntity, Accommodation>();
            CreateMap<Accommodation, AccommodationResponse>();
            CreateMap<AccommodationRequest, Accommodation>();
            
            CreateMap<SupplierQueryParamsResponse, SupplierQueryParams>();
            CreateMap(typeof(SupplierPage<>), typeof(SupplierPageResponse<>));
        }
    }
}