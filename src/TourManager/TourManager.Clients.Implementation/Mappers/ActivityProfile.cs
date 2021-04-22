using AutoMapper;
using Activity = TourManager.Common.Clients.Activity;
using ActivityModel = Travely.ServiceManager.Service.Activity;
using ActivityType = TourManager.Common.Clients.ActivityType;
using ActivityTypeModel = Travely.ServiceManager.Service.ActivityType;
using ActivityResponse = TourManager.Common.Clients.ResponseStatus;
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
                .ForMember(a => a.Price, o => o.MapFrom(a => new Price() {
                    Price_ = a.Price
                                                                        })).ReverseMap();
            CreateMap<ActivityModel, Activity>()
                .ForMember(a => a.Price, o => o.MapFrom(a => a.Price.Price_)).ReverseMap();
            CreateMap<TourManager.Common.Clients.Activity, Travely.ServiceManager.Service.Activity>().ReverseMap();
        }
    }
}
