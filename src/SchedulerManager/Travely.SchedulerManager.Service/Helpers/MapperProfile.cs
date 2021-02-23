using AutoMapper;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Service.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //TODO
            CreateMap<ScheduleInfo, Notification>()
                .ForMember(dto => dto.BookingId, entity => entity.MapFrom(src => src.RecurseId));
            //.ForMember(dto => dto.Message, entity => entity.MapFrom(src => $"{} booking for {} tour will expire in {}"));
        }
    }
}