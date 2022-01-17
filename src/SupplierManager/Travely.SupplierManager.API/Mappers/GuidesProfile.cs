using AutoMapper;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Mappers
{
    public class GuidesProfile : Profile
    {
        public GuidesProfile() 
        {
            CreateMap<Guides, GuidesEntity>();
            CreateMap<GuidesEntity, Guides>();
            CreateMap<Guide, GuideEntity>();
            CreateMap<GuideEntity, Guide>();
            CreateMap<string, AttachmentEntity>();
        }
    }
}