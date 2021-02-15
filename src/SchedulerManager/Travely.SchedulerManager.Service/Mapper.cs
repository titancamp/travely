using AutoMapper;
using System.Linq;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Service
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ScheduleInfo, NotificationDTO>()
                .ForMember(dto => dto.BookingId, entity => entity.MapFrom(src => src.RecurseId))
                .ForMember(dto => dto.Message, entity => entity.MapFrom(src => src.JsonData))
                .ForMember(dto => dto.NotifyDate, entity => entity.MapFrom(src => src.ExpirationDate));

            //TODO
            CreateMap<CreateNotificationDTO, ScheduleInfo>()
                .ForMember(entity => entity.RecurseId, dto => dto.MapFrom(src => src.BookingId))
                .ForMember(entity => entity.ExpirationDate, dto => dto.MapFrom(src => src.NotifyDate))
                .ForMember(entity => entity.JsonData, dto => dto.MapFrom(src => src.Message))
                .ForMember(entity => entity.UserSchedules, dto => dto.MapFrom(src => src.UserIds.Select(id => new UserSchedule()
                {
                    UserId = id
                }).ToList()));
        }
    }
}
