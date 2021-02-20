using AutoMapper;
using System.Linq;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Service
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //TODO
            CreateMap<ScheduleInfo, NotificationDTO>()
                .ForMember(dto => dto.BookingId, entity => entity.MapFrom(src => src.RecurseId));
                //.ForMember(dto => dto.Message, entity => entity.MapFrom(src => $"{} booking for {} tour will expire in {}"));
        }
    }
}