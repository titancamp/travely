using AutoMapper;
using ClientManager.Protos;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.ClientManager.Domain.Entity.Client;

namespace Travely.ClientManager.Service.Mappers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientModel>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.CreatedDate, DateTimeKind.Utc).ToTimestamp()));

            CreateMap<ClientModel, Client>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ToDateTime()));


        }


    }
}
