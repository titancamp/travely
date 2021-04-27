using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using System;
using TourManager.Service.Model;
using Travely.ClientManager.Service.Protos;

namespace TourManager.Clients.Implementation.Mappers
{
    public class ClientManagerClientProfile : Profile
    {
        public ClientManagerClientProfile()
        {
            CreateMap<DateTime, Timestamp>().ConvertUsing((s, d) =>
            {
                return Timestamp.FromDateTime(DateTime.SpecifyKind(s, DateTimeKind.Utc));
            });
            CreateMap<Timestamp, DateTime>().ConvertUsing((s, d) =>
            {
                return s.ToDateTime();
            });

            CreateMap<ClientModel, Client>();
            CreateMap<Client, ClientModel>();
        }
    }
}
