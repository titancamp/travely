using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
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
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                //.AfterMap((src, dest) => dest.Password = Guid.NewGuid().ToString())
                .AfterMap((src, dest) => dest.Status = Status.Inactive)
                .AfterMap((src, dest) => dest.Role = Role.User)
                .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow);

            CreateMap<UpdateUserRequestModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                //.AfterMap((src, dest) => dest.Password = Guid.NewGuid().ToString())
                .AfterMap((src, dest) => dest.Status = Status.Inactive)
                .AfterMap((src, dest) => dest.Role = Role.User)
                .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow);

            CreateMap<RegisterRequestModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Agency, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .AfterMap((src, dest) => dest.Password = passwordHasher.HashPassword(dest, dest.Password))
                .AfterMap((src, dest) => dest.Status = Status.Active)
                .AfterMap((src, dest) => dest.Role = Role.Admin)
                .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow);

            CreateMap<RegisterRequestModel, Agency>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AgencyName))
                .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow);

            CreateMap<User, UserResponseModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                ;
        }
    }
}
