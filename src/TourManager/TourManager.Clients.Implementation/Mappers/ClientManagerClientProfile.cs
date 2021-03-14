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
			CreateMap<ClientModel, Client>()
				.ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToDateTime()))
				.ForMember(dest => dest.ExpireDate, opt => opt.MapFrom(src => src.ExpireDate.ToDateTime()))
				.ForMember(dest => dest.IssuedDate, opt => opt.MapFrom(src => src.IssuedDate.ToDateTime()));

			CreateMap<Client, ClientModel>()
				.ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.HasValue ? src.DateOfBirth.Value.ToTimestamp() : null))
				.ForMember(dest => dest.ExpireDate, opt => opt.MapFrom(src => src.ExpireDate.HasValue ? src.ExpireDate.Value.ToTimestamp() : null))
				.ForMember(dest => dest.IssuedDate, opt => opt.MapFrom(src => src.IssuedDate.HasValue ? src.IssuedDate.Value.ToTimestamp() : null));

		}
	}
}
