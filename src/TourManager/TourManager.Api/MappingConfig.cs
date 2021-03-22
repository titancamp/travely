using System.Collections.Generic;
using AutoMapper;
using TourManager.Api.Models.Requests;
using TourManager.Api.Utils;
using TourManager.Common.Clients.PropertyManager;
using TourManager.Repository.Entities;
using TourManager.Service.Model;

namespace TourManager.Api
{
    /// <summary>
    /// Model for model mapping configurations
    /// </summary>
    public class MappingConfig : Profile
    {
        /// <summary>
        /// Create new instance of mapping configuration
        /// </summary>
        public MappingConfig()
        {
            // client mappings
            this.CreateMap<Client, ClientEntity>();
            this.CreateMap<ClientEntity, Client>();
            this.CreateMap<List<ClientEntity>, List<Client>>();

            // booking mappings
            this.CreateMap<Booking, BookingEntity>();
            this.CreateMap<BookingEntity, Booking>();
            this.CreateMap<List<BookingEntity>, List<Booking>>();

            // tour mappings
            this.CreateMap<Tour, TourEntity>().ForMember(dest => dest.Description, act => act.MapFrom(src => src.Notes));
            this.CreateMap<TourEntity, Tour>().ForMember(dest => dest.Notes, act => act.MapFrom(src => src.Description));
            this.CreateMap<List<TourEntity>, List<Tour>>();

            // property mappings
            this.CreateMap<AddPropertyRequestModel, AddPropertyRequest>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name ?? string.Empty))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address ?? string.Empty))
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName ?? string.Empty))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email ?? string.Empty))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone ?? string.Empty))
                .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.Website ?? string.Empty))
                .ForMember(dest => dest.AttachmentsToAdd, act => act.MapFrom(src => src.AttachmentsToAdd.ToFileModelCollection()));
        }
    }
}
