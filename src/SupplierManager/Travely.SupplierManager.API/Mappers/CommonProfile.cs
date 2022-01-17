using AutoMapper;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Mappers
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<Location, LocationEntity>();
            CreateMap<LocationEntity, Location>();
            CreateMap<Attachment, AttachmentEntity>();
            CreateMap<AttachmentEntity, Attachment>();
        }
    }
}