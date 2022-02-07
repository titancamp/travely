using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using Travely.Common.Entities;
using Travely.IdentityManager.Repository.Abstractions.Entities;
using Travely.IdentityManager.Service.Abstractions.Models.Request;
using Travely.IdentityManager.Service.Abstractions.Models.Response;

namespace Travely.IdentityManager.WebApi.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile(IPasswordHasher<User> passwordHasher)
        {
            CreateMap<UserRequestModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .AfterMap((src, dest) => dest.Permissions = src.Permission)
                .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow)
                .AfterMap((src, dest) => dest.Email = src.Email);

            CreateMap<RegisterRequestModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Agency, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .AfterMap((src, dest) => dest.Password = passwordHasher.HashPassword(dest, dest.Password))
                .AfterMap((src, dest) => dest.Status = Status.Active)
                .AfterMap((src, dest) => dest.Permissions = Permission.Admin)
                .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow);

            CreateMap<RegisterRequestModel, Agency>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AgencyName))
                .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow);

            CreateMap<User, UserResponseModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Permission, opt => opt.MapFrom(src => src.Permissions))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.LastLogin, opt => opt.MapFrom(src => src.LastLogin))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                ;
        }
    }
}
