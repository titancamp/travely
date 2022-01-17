using AutoMapper;
using TourEntities.Service.Accommodation;
using Travely.SupplierManager.API.Models;
using Travely.SupplierManager.API.Requests;
using Travely.SupplierManager.API.Responses;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;
using Accommodation = Travely.SupplierManager.Service.Models.Accommodation;

namespace Travely.SupplierManager.API.Mappers
{
    public class AccommodationProfile : Profile
    {
        public AccommodationProfile()
        {
            CreateMap<Accommodation, AccommodationEntity>();

            CreateMap<AccommodationService, AccommodationServiceEntity>();
            CreateMap<AccommodationServiceEntity, AccommodationService>();
            CreateMap<RoomService, RoomServiceEntity>();
            CreateMap<RoomServiceEntity, RoomService>();
            
            CreateMap<Room, RoomEntity>();
            CreateMap<RoomEntity, Room>();
            
            CreateMap<AccommodationEntity, Accommodation>();
            
            CreateMap<Accommodation, AccommodationResponse>();
            CreateMap<AccommodationRequest, Accommodation>();

            CreateMap<SupplierQueryParamsResponse, SupplierQueryParams>();
            CreateMap(typeof(SupplierPage<>), typeof(SupplierPageResponse<>));
        }
    }
}