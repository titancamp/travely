using AutoMapper;
using IdentityServer4.Models;
using entityModel = Travely.IdentityManager.Repository.Abstractions.Entities;

namespace IdentityManager.DataService.Mappers
{
    public class PersistGrantProfile : Profile
    {
        public PersistGrantProfile()
        {
            CreateMap<entityModel.PersistedGrant, PersistedGrant>(MemberList.Destination)
                .ReverseMap();
        }

    }
}
