using System.Linq;
using AutoMapper;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Mappers
{
    public class TransportationProfile : Profile
    {
        public TransportationProfile()
        {
            CreateMap<Transportation, TransportationEntity>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Driver, DriverEntity>().ReverseMap();
            CreateMap<Car, CarEntity>().ReverseMap();
            CreateMap<Language, LanguageEntity<DriverEntity>>().ReverseMap();
            CreateMap<Attachment, AttachmentEntity<TransportationEntity>>().ReverseMap();
            CreateMap<LicenseTypeEntity, LicenseTypeModel>().ReverseMap();
        }
    }
}