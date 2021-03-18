using AutoMapper;

using Travely.IdentityManager.Repository.Abstractions.Entities;

using Travely.IdentityManager.Service.Abstractions.Models.Request;

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
