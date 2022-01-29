using AutoMapper;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Mappers
{
    public class GuidesProfile : Profile
    {
        public GuidesProfile() 
        {
            CreateMap<GuidesModel, GuidesEntity>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Guide, GuideEntity>().ReverseMap();
            CreateMap<Language, LanguageEntity<GuideEntity>>().ReverseMap();
            CreateMap<Attachment, AttachmentEntity<GuidesEntity>>().ReverseMap();
        }
    }
}