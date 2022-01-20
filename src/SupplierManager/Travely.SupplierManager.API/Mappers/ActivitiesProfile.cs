using System.Linq;
using AutoMapper;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Mappers
{
    public class ActivitiesProfile : Profile
    {
        public ActivitiesProfile()
        {
            
            CreateMap<Activities, ActivitiesEntity>().ForMember(dst => dst.Attributes, opt => opt.MapFrom(src => src.Attributes.Select(x => new AttributeEntity{ Name = x })));
            CreateMap<ActivitiesEntity, Activities>().ForMember(dst => dst.Attributes, opt => opt.MapFrom(src => src.Attributes.Select(x => x.Name)));
            
            CreateMap<Attachment, AttachmentEntity<ActivitiesEntity>>().ReverseMap();
        }
    }
}