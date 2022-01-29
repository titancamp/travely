using AutoMapper;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Mappers
{
    public class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<Food, FoodEntity>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Menu, MenuEntity>().ReverseMap();
            CreateMap<Tag, TagEntity>().ReverseMap();
            CreateMap<Attachment, AttachmentEntity<FoodEntity>>().ReverseMap();
            CreateMap<Attachment, AttachmentEntity<MenuEntity>>().ReverseMap();
        }
    }
}