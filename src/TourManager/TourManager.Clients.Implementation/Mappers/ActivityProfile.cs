using AutoMapper;
using Travely.ServiceManager.Service;
using Activity = TourManager.Common.Clients.Activity;
using ActivityModel = Travely.ServiceManager.Service.Activity;
using ActivityType = TourManager.Common.Clients.ActivityType;
using ActivityTypeModel = Travely.ServiceManager.Service.ActivityType;

namespace TourManager.Clients.Implementation.Mappers
{
    public class ActivityClientProfile : Profile
    {
        public ActivityClientProfile()
        {
            CreateMap<ActivityType, ActivityTypeModel>().ReverseMap();
            CreateMap<Common.Clients.ActivityResponse, ActivityResponse>()
                .ForMember(a => a.Status, o => o.MapFrom(a => (ResponseStatus)(int)a.Status))
                .ForMember(a => a.Message, o => o.MapFrom(a => a.Message))
                .ReverseMap();
            CreateMap<Activity, ActivityModel>()
                .ReverseMap();
            CreateMap<ActivityModel, Activity>()
                .ForMember(a => a.Price, o => o.MapFrom(a => a.Price))
                .ReverseMap();
            CreateMap<TourManager.Common.Clients.Activity, Travely.ServiceManager.Service.Activity>().ReverseMap();
        }
    }
}
