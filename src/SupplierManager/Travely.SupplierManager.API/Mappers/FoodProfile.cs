using AutoMapper;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Mappers
{
    public class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<Food, FoodEntity>();
            CreateMap<FoodEntity, Food>();
            CreateMap<FoodTypeEntity, FoodType>();
            CreateMap<FoodType, FoodTypeEntity>();
            
            CreateMap<Menu, MenuEntity>();
            CreateMap<MenuEntity, Menu>();
            CreateMap<Tag, TagEntity>();
            CreateMap<TagEntity, Tag>();
        }
    }
}