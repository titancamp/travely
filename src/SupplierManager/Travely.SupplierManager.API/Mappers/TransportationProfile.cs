using AutoMapper;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Mappers
{
    public class TransportationProfile : Profile
    {
        public TransportationProfile()
        {
            CreateMap<Transportation, TransportationEntity>();
            CreateMap<TransportationEntity, Transportation>();
            CreateMap<TransportationType, TransportationTypeEntity>();
            CreateMap<TransportationTypeEntity, TransportationType>();
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