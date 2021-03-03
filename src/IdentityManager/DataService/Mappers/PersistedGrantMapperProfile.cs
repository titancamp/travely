using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions.Entities;
using IdentityServer4.Models;

namespace IdentityManager.DataService.Mappers
{
    public class PersistedGrantMapperProfile : Profile
    {
        /// <summary>
        /// <see cref="PersistedGrantMapperProfile">
        /// </see>
        /// </summary>
        public PersistedGrantMapperProfile()
        {
            CreateMap<Travely.IdentityManager.Repository.Abstractions.Entities.PersistedGrant, IdentityServer4.Models.PersistedGrant>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
