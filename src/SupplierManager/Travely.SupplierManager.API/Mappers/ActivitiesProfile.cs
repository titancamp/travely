using AutoMapper;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Mappers
{
    public class ActivitiesProfile : Profile
    {
        public ActivitiesProfile()
        {
            CreateMap<Activities, ActivitiesEntity>();
            CreateMap<ActivitiesEntity, Activities>();
            CreateMap<string, AttributeEntity>();
            CreateMap<ActivitiesEntity, string>();
        }
    }
}