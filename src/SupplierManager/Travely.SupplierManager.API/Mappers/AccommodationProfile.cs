using System.Linq;
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
            CreateMap<Accommodation, AccommodationEntity>().ForMember(dst => dst.Services, opt => opt.MapFrom(src => src.Services.Select(x => new AccommodationServiceEntity{ Service = x})));
            CreateMap<AccommodationEntity, Accommodation>().ForMember(dst => dst.Services, opt => opt.MapFrom(src => src.Services.Select(x => x.Service)));
            
            CreateMap<Room, RoomEntity>().ForMember(dst => dst.Services, opt => opt.MapFrom(src => src.Services.Select(x => new RoomServiceEntity{ Service = x})));
            CreateMap<RoomEntity, Room>().ForMember(dst => dst.Services, opt => opt.MapFrom(src => src.Services.Select(x => x.Service)));

            CreateMap<Accommodation, AccommodationResponse>();
            CreateMap<AccommodationRequest, Accommodation>();
            
            CreateMap<Attachment, AttachmentEntity<AccommodationEntity>>().ReverseMap();
        }
    }
}