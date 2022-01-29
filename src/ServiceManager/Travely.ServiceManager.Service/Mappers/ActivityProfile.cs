using AutoMapper;
using Travely.ServiceManager.Grpc;
using DbModels = Travely.ServiceManager.Abstraction.Models.Db;

namespace Travely.ServiceManager.Service.Mappers
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<Activity, DbModels.Activity>()
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.ActivityType, opt => opt.MapFrom(src => src.Type))
                .ForPath(dest => dest.ActivityType.Name, opt => opt.MapFrom(src => src.Type.ActivityName));

            CreateMap<DbModels.Activity, Activity>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.ActivityType))
                .ForPath(dest => dest.Type.ActivityName, opt => opt.MapFrom(src => src.ActivityType.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailAddress));

            CreateMap<ActivityType, DbModels.ActivityType>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ActivityName));

            CreateMap<DbModels.ActivityType, ActivityType>()
                .ForMember(dest => dest.ActivityName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
