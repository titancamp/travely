using AutoMapper;
using Activity = TourManager.Common.Clients.Activity;
using ActivityModel = Travely.ServiceManager.Service.Activity;
using ActivityType = TourManager.Common.Clients.ActivityType;
using ActivityTypeModel = Travely.ServiceManager.Service.ActivityType;
using ActivityResponse = TourManager.Common.Clients.ActivityResponse;
using ActivityResponseModel = Travely.ServiceManager.Service.ActivityResponse;
using Travely.ServiceManager.Service;

namespace TourManager.Clients.Implementation.Mappers
{
    public class ActivityClientProfile : Profile
    {
        public ActivityClientProfile()
        {
            CreateMap<ActivityType, ActivityTypeModel>().ReverseMap();
            CreateMap<ActivityResponseModel, ActivityResponse>().ReverseMap();
            CreateMap<Activity, ActivityModel>()
                .ForMember(a => a.Price, o => o.MapFrom(a => new Price()
                {
                    Currency = a.Currency,
                    Price_ = a.Price
                }));
            CreateMap<ActivityModel, Activity>()
                .ForMember(a => a.Currency, o => o.MapFrom(a => a.Price.Currency))
                .ForMember(a => a.Price, o => o.MapFrom(a => a.Price.Price_));
        }
    }
}
