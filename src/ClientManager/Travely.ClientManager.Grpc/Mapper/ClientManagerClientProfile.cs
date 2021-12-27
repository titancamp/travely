using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using System;

namespace Travely.ClientManager.Grpc.Mapper
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

            CreateMap<ClientModel, Models.Client>().ReverseMap();
        }
    }
}
