using AutoMapper;
using Travely.SchedulerManager.Grpc.Client.Models;

namespace Travely.SchedulerManager.Grpc.Client.Mapper
{
    public class SchedulerClientProfile : Profile
    {
        public SchedulerClientProfile()
        {
            // TODO: there are no CreateRequest and UpdateRequest models
            //CreateMap<CreateUpdateReminderRequest, CreateRequest>();
            //CreateMap<CreateUpdateReminderRequest, UpdateRequest>();

            CreateMap<CreateUpdateReminderRequest, CreateScheduledNotificationRequest>();
            CreateMap<CreateUpdateReminderRequest, UpdateScheduledNotificationRequest>();
            CreateMap<Notification, ReminderNotification>().ReverseMap();
        }
    }
}
