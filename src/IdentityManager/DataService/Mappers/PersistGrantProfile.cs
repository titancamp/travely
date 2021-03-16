using AutoMapper;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
