using AutoMapper;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Mappers
{
    public class ActivitiesProfile : Profile
    {
        public ActivitiesProfile()
        {
            CreateMap<Activities, ActivitiesEntity>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Attribute, AttributeEntity>().ReverseMap();
            CreateMap<Attachment, AttachmentEntity<ActivitiesEntity>>().ReverseMap();
        }
    }
}