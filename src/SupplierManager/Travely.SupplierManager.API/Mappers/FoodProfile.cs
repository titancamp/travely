using AutoMapper;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Mappers
{
    public class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<Food, FoodEntity>().ReverseMap();
            
            CreateMap<Menu, MenuEntity>().ReverseMap();
            CreateMap<Tag, TagEntity>().ReverseMap();
            
            CreateMap<Attachment, AttachmentEntity<FoodEntity>>().ReverseMap();
            CreateMap<Attachment, AttachmentEntity<MenuEntity>>().ReverseMap();
        }
    }
}