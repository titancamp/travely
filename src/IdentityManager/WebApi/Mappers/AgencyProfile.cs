using AutoMapper;

using Travely.IdentityManager.Repository.Abstractions.Entities;
using Travely.IdentityManager.Service.Abstractions.Models.Request;
using Travely.IdentityManager.Service.Abstractions.Models.Response;

namespace Travely.IdentityManager.WebApi.Mappers
{
    public class AgencyProfile : Profile
    {
        public AgencyProfile()
        {
            CreateMap<Agency, AgencyResponseModel>()
                .ReverseMap();

            CreateMap<Agency, UpdateAgencyRequestModel>()
                .ReverseMap();
        }

    }
}
