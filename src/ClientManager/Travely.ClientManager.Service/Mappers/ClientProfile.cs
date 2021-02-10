using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.ClientManager.Repository.Entity.Client;
using Travely.ClientManager.Service.Protos;

namespace Travely.ClientManager.Service.Mappers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Turist, ClientModel>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.CreatedDate, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.DateOfBirth, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(dest => dest.IssuedDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.IssuedDate, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(dest => dest.ExpireDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.ExpireDate, DateTimeKind.Utc).ToTimestamp()));

            CreateMap<ClientModel, Turist>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ToDateTime()))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToDateTime()))
                .ForMember(dest => dest.IssuedDate, opt => opt.MapFrom(src => src.IssuedDate.ToDateTime()))
                .ForMember(dest => dest.ExpireDate, opt => opt.MapFrom(src => src.ExpireDate.ToDateTime()));

            CreateMap<Turist, ClientWithPreferencesModel>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.CreatedDate, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.DateOfBirth, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(dest => dest.IssuedDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.IssuedDate, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(dest => dest.ExpireDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.ExpireDate, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(dest => dest.Preferences, opt => opt.MapFrom(src => src.Preferences.Select(x => new PreferenceModel
                {
                    Id = x.Id,
                    Note = x.Note,
                    CreatedDate = DateTime.SpecifyKind(x.CreatedDate, DateTimeKind.Utc).ToTimestamp()
                }).ToList()));
                
                
                
                
                //(src, dest) => dest.Preferences.AddRange(src.Preferences.Select(x => new PreferenceModel
                //{
                //     Id = x.Id,
                //     Note = x.Note,
                //     CreatedDate = DateTime.SpecifyKind(x.CreatedDate, DateTimeKind.Utc).ToTimestamp()
                //})));

        }


    }
}
