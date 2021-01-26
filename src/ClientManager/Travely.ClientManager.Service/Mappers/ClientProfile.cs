using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.ClientManager.Domain.Entity.Client;
using Travely.ClientManager.Service.Protos;

namespace Travely.ClientManager.Service.Mappers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientModel>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.CreatedDate, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.DateOfBirth, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(dest => dest.IssuedDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.IssuedDate, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(dest => dest.ExpireDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.ExpireDate, DateTimeKind.Utc).ToTimestamp()));

            CreateMap<ClientModel, Client>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ToDateTime()))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToDateTime()))
                .ForMember(dest => dest.IssuedDate, opt => opt.MapFrom(src => src.IssuedDate.ToDateTime()))
                .ForMember(dest => dest.ExpireDate, opt => opt.MapFrom(src => src.ExpireDate.ToDateTime()));

            CreateMap<Client, ClientWithPreferencesModel>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.CreatedDate, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.DateOfBirth, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(dest => dest.IssuedDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.IssuedDate, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(dest => dest.ExpireDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.ExpireDate, DateTimeKind.Utc).ToTimestamp()))
                .AfterMap((source, dest) => dest.Preferences.AddRange(source.ClientPreferences.Select(x=> new PreferenceModel 
                                                                    {
                                                                        Id = x.Preference.Id,
                                                                        Note = x.Preference.Note,
                                                                        CreatedDate = DateTime.SpecifyKind(x.Preference.CreatedDate, DateTimeKind.Utc).ToTimestamp()
                                                                    })));
                //.ForMember(dest => dest.Preferences, opt => opt.MapFrom(src => src.ClientPreferences.Select(x => x.Preference).ToList())));

        }


    }
}
