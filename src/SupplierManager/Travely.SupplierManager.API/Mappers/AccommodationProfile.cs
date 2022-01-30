using AutoMapper;
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
            CreateMap<Accommodation, AccommodationEntity>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<AccommodationServiceModel, AccommodationServiceEntity>().ReverseMap();
            CreateMap<Room, RoomEntity>().ReverseMap();
            CreateMap<RoomServiceModel, RoomServiceEntity>().ReverseMap();
            CreateMap<Accommodation, AccommodationResponse>();
            CreateMap<AccommodationRequest, Accommodation>();
            CreateMap<Attachment, AttachmentEntity<AccommodationEntity>>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}