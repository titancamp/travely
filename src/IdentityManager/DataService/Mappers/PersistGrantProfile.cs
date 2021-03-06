using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityManager.DataService.Mappers
{
    public class PersistGrantProfile : Profile
    {
        public PersistGrantProfile()
        {
            CreateMap<Travely.IdentityManager.Repository.Abstractions.Entities.PersistedGrant, IdentityServer4.Models.PersistedGrant>(MemberList.Destination)
                .ReverseMap();
        }

    }
}
