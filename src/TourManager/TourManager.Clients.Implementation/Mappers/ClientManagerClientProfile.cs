using System;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using TourManager.Service.Model;
using Travely.ClientManager.Service.Protos;

namespace TourManager.Clients.Implementation.Mappers
{
	public class ClientManagerClientProfile : Profile
	{
		public ClientManagerClientProfile()
		{
			CreateMap<DateTime?, Timestamp>()
				.ConvertUsing(x => x.HasValue ? Timestamp.FromDateTime(DateTime.SpecifyKind(x.Value, DateTimeKind.Utc)) : null);
			CreateMap<DateTime, Timestamp>()
				.ConvertUsing(x => Timestamp.FromDateTime(DateTime.SpecifyKind(x, DateTimeKind.Utc)));
			CreateMap<Timestamp, DateTime>()
				.ConvertUsing(x => x.ToDateTime());

			CreateMap<ClientModel, Client>();

			CreateMap<Client, ClientModel>();

		}
	}
}
