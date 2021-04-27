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
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src))
                //.AfterMap((src, dest) => dest.Password = Guid.NewGuid().ToString())
                .AfterMap((src, dest) => dest.Status = Status.Inactive)
                .AfterMap((src, dest) => dest.Role = Role.User)
                .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow);

            CreateMap<UserRequestModel, Employee>()
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.Title))
               .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow);

            CreateMap<UpdateUserRequestModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src))
                //.AfterMap((src, dest) => dest.Password = Guid.NewGuid().ToString())
                .AfterMap((src, dest) => dest.Status = Status.Inactive)
                .AfterMap((src, dest) => dest.Role = Role.User)
                .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow);

            CreateMap<UpdateUserRequestModel, Employee>()
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.Title))
               .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow);

            CreateMap<RegisterRequestModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Agency, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src))
                .AfterMap((src, dest) => dest.Password = passwordHasher.HashPassword(dest, dest.Password))
                .AfterMap((src, dest) => dest.Status = Status.Active)
                .AfterMap((src, dest) => dest.Role = Role.Admin)
                .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow);

            CreateMap<RegisterRequestModel, Agency>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AgencyName))
                .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow);

            CreateMap<RegisterRequestModel, Employee>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .AfterMap((src, dest) => dest.CreatedDate = DateTime.UtcNow);


            CreateMap<Employee, UserResponseModel>();

            CreateMap<User, UserResponseModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Employee.Email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Employee.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Employee.LastName))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.Employee.JobTitle))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Employee.PhoneNumber))
                ;
        }
    }
}
