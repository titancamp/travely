using AutoMapper;
using IdentityManager.WebApi.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace IdentityManager.WebApi.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, UpdateAgencyRequestModel>()
                .ForMember(dest => dest.LogoFile, opt => opt.MapFrom(src => src.Agency.LogoFile))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Agency.Address))
                .ReverseMap();
        }


    }
}
