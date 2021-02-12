using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.ClientManager.Abstraction.Entity;
using Travely.ClientManager.Service.Protos;

namespace Travely.ClientManager.Service.Mappers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Tourist, ClientModel>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.CreatedDate, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src =>
                    src.DateOfBirth.HasValue ? DateTime.SpecifyKind(src.DateOfBirth.Value, DateTimeKind.Utc).ToTimestamp() : null))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src =>
                    src.IssuedDate.HasValue ? DateTime.SpecifyKind(src.IssuedDate.Value, DateTimeKind.Utc).ToTimestamp() : null))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src =>
                    src.ExpireDate.HasValue ? DateTime.SpecifyKind(src.ExpireDate.Value, DateTimeKind.Utc).ToTimestamp() : null));


            CreateMap<ClientModel, Tourist>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ToDateTime()))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToDateTime()))
                .ForMember(dest => dest.IssuedDate, opt => opt.MapFrom(src => src.IssuedDate.ToDateTime()))
                .ForMember(dest => dest.ExpireDate, opt => opt.MapFrom(src => src.ExpireDate.ToDateTime()));



            CreateMap<Tourist, ClientWithPreferencesModel>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.CreatedDate, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src =>
                    src.DateOfBirth.HasValue ? DateTime.SpecifyKind(src.DateOfBirth.Value, DateTimeKind.Utc).ToTimestamp() : null))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src =>
                    src.IssuedDate.HasValue ? DateTime.SpecifyKind(src.IssuedDate.Value, DateTimeKind.Utc).ToTimestamp() : null))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src =>
                    src.ExpireDate.HasValue ? DateTime.SpecifyKind(src.ExpireDate.Value, DateTimeKind.Utc).ToTimestamp() : null))
                .ForMember(dest => dest.Preferences, opt => opt.MapFrom(src => src.Preferences.Select(x => new PreferenceModel
                {
                    Id = x.Id,
                    Note = x.Note,
                    CreatedDate = DateTime.SpecifyKind(x.CreatedDate, DateTimeKind.Utc).ToTimestamp()
                }).ToList()));

        }


    }
}
