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
            CreateMap<Driver, DriverEntity>();
            CreateMap<DriverEntity, Driver>();
            CreateMap<Car, CarEntity>();
            CreateMap<CarEntity, Car>();
            CreateMap<LicenseType, LicenseTypeEntity>();
            CreateMap<LicenseTypeEntity, LicenseType>();
            CreateMap<Language, LanguageEntity>();
            CreateMap<LanguageEntity, Language>();
        }
    }
}