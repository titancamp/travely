using System;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using Travely.SchedulerManager.Common.Enums;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Service.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //TODO from UpdateNotificationModel to ScheduleInfo

            CreateMap<BookingCancellationExpirationNotificationModel, NotificationModel>()
                .ForMember(dto => dto.RecurseId, entity => entity.MapFrom(src => src.BookingId))
                .ForMember(dto => dto.Module, entity => entity.MapFrom(src => TravelyModule.Booking))
                .ForMember(dto => dto.MessageTemplate, entity => entity.MapFrom(src => MessageTemplate.BookingCancellationExpiration))
                .ForMember(dto => dto.ExpirationDate, entity => entity.MapFrom(src => src.BookingCancellationDate))
                .ForMember(dto => dto.JsonData, entity => entity.MapFrom(src => JsonConvert.SerializeObject(new
                {
                    src.BookingId,
                    src.TourId,
                    src.BookingCancellationDate,
                    src.BookingName,
                    src.NumberOfDaysUntilExpiration,
                    src.TourName
                })));

            CreateMap<ChangeInTourFieldNotificationModel, NotificationModel>()
                .ForMember(dto => dto.RecurseId, entity => entity.MapFrom(src => src.TourId))
                .ForMember(dto => dto.Module, entity => entity.MapFrom(src => TravelyModule.Tour))
                .ForMember(dto => dto.MessageTemplate, entity => entity.MapFrom(src => MessageTemplate.ChangeInTourField))
                .ForMember(dto => dto.ExpirationDate, entity => entity.MapFrom(src => DateTime.Now))
                .ForMember(dto => dto.JsonData, entity => entity.MapFrom(src => JsonConvert.SerializeObject(new
                {
                    src.TourId,
                    src.ChangedFieldName,
                    src.NewValue,
                    src.OldValue,
                    src.TourName,
                    src.UserIdWhoMadeTheChange,
                    src.UserWhoMadeTheChange,
                })));

            CreateMap<IncompleteBookingRequestsNotificationModel, NotificationModel>()
                .ForMember(dto => dto.RecurseId, entity => entity.MapFrom(src => src.TourId))
                .ForMember(dto => dto.Module, entity => entity.MapFrom(src => TravelyModule.Tour))
                .ForMember(dto => dto.MessageTemplate, entity => entity.MapFrom(src => MessageTemplate.IncompleteBookingRequests))
                .ForMember(dto => dto.ExpirationDate, entity => entity.MapFrom(src => src.TourStartDate))
                .ForMember(dto => dto.JsonData, entity => entity.MapFrom(src => JsonConvert.SerializeObject(new
                {
                    src.TourId,
                    src.TourName,
                    src.TourStartDate,
                })));

            CreateMap<TourIsApproachingNotificationModel, NotificationModel>()
                .ForMember(dto => dto.RecurseId, entity => entity.MapFrom(src => src.TourId))
                .ForMember(dto => dto.Module, entity => entity.MapFrom(src => TravelyModule.Tour))
                .ForMember(dto => dto.MessageTemplate, entity => entity.MapFrom(src => MessageTemplate.TourIsApproaching))
                .ForMember(dto => dto.ExpirationDate, entity => entity.MapFrom(src => src.TourStartDate))
                .ForMember(dto => dto.JsonData, entity => entity.MapFrom(src => JsonConvert.SerializeObject(new
                {
                    src.TourId,
                    src.TourName,
                    src.TourStartDate,
                })));

            CreateMap<TourStartDateChangeNotificationModel, NotificationModel>()
                .ForMember(dto => dto.RecurseId, entity => entity.MapFrom(src => src.TourId))
                .ForMember(dto => dto.Module, entity => entity.MapFrom(src => TravelyModule.Tour))
                .ForMember(dto => dto.MessageTemplate, entity => entity.MapFrom(src => MessageTemplate.TourIsApproaching))
                .ForMember(dto => dto.ExpirationDate, entity => entity.MapFrom(src => src.StartDate))
                .ForMember(dto => dto.JsonData, entity => entity.MapFrom(src => JsonConvert.SerializeObject(new
                {
                    src.TourId,
                    src.TourName,
                    src.StartDate,
                    src.OldStartDate,
                    src.UserWhoMadeTheChange
                })));

            CreateMap<ScheduleInfo, NotificationGeneratedModel>()
                .ForMember(dto => dto.ScheduleId, entity => entity.MapFrom(src => src.Id))
                .ForMember(dto => dto.RecurseId, entity => entity.MapFrom(src => src.RecurseId))
                .ForMember(dto => dto.Module, entity => entity.MapFrom(src => src.Module))
                .ForMember(dto => dto.UserIds, entity => entity.MapFrom(src => src.UserSchedules.Select(s => s.UserId).ToList()));
        }
    }
}