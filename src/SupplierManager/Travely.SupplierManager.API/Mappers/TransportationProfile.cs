using System.Linq;
using AutoMapper;
using TourEntities.Service.Transportation;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;
using Car = Travely.SupplierManager.Service.Models.Car;
using Driver = Travely.SupplierManager.Service.Models.Driver;

namespace Travely.SupplierManager.API.Mappers
{
    public class TransportationProfile : Profile
    {
        public TransportationProfile()
        {
            CreateMap<Transportation, TransportationEntity>();
            CreateMap<TransportationEntity, Transportation>();
            CreateMap<Driver, DriverEntity>().ForMember(dst => dst.LicenseType, opt => opt.MapFrom(src => src.LicenseType.Select(x => new LicenseTypeEntity{ LicenseType = x})));
            CreateMap<DriverEntity, Driver>().ForMember(dst => dst.LicenseType, opt => opt.MapFrom(src => src.LicenseType.Select(x => x.LicenseType)));
            CreateMap<Car, CarEntity>();
            CreateMap<CarEntity, Car>();
            
            CreateMap<Language, LanguageEntity<DriverEntity>>();
            CreateMap<LanguageEntity<DriverEntity>, Language>();
        }
    }
}