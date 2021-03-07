using AutoMapper;
using IdentityManager.API.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace IdentityManager.WebApi.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile(IPasswordHasher<User> passwordHasher)
        {
            CreateMap<RegisterRequestModel, User>()                
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Agency, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src))
                .AfterMap((src, dest) => dest.Password = passwordHasher.HashPassword(dest, dest.Password))
                .AfterMap((src, dest) => dest.Status = Status.Active)
                .AfterMap((src, dest) => dest.Role = Role.Admin)
                .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow)
                ;

            CreateMap<RegisterRequestModel, Agency>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AgencyName))
                .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow)
                ;
            
            CreateMap<RegisterRequestModel, Employee>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow)
                ;


        }

    }
}
