using AutoMapper;
using TourManager.Service.Model.SchedulerManager.Reminders;
using Travely.SchedulerManager.API;

namespace TourManager.Clients.Implementation.Mappers
{
    public class SchedulerClientProfile : Profile
    {
        public SchedulerClientProfile()
        {
            CreateMap<CreateUpdateReminderRequest, CreateRequest>();
            CreateMap<CreateUpdateReminderRequest, UpdateRequest>();
            CreateMap<Notification, ReminderNotification>().ReverseMap();
        }
    }
}
