using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using System;
using Travely.ClientManager.Abstraction.Entity;
using Travely.ClientManager.Service.Protos;

namespace Travely.ClientManager.Service.Mappers
{
    public class PreferenceProfile : Profile
    {
        public PreferenceProfile() 
        {
            CreateMap<Preference, PreferenceModel>()
                 .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.CreatedDate, DateTimeKind.Utc).ToTimestamp()));

            CreateMap<PreferenceModel, Preference>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ToDateTime()));
        }
    }
}
