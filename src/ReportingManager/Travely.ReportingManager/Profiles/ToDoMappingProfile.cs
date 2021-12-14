using System;
using System.Collections.Generic;
using AutoMapper;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Travely.ReportingManager.Profiles.Converters;
using Travely.ReportingManager.Protos;
using Travely.ReportingManager.Services.Models.Commands;
using Travely.ReportingManager.Services.Models.Queries;
using Travely.ReportingManager.Services.Models.Responses;

namespace Travely.ReportingManager.Profiles
{
    public class ToDoMappingProfile : Profile
    {
        public ToDoMappingProfile()
        {
            CreateMap(typeof(RepeatedField<>), typeof(ICollection<>)).ConvertUsing(typeof(RepeatedFieldToCollectionConverter<,>));

            CreateMap<Travely.PropertyManager.API.OrderingBaseModel, Travely.ReportingManager.Services.Models.Base.OrderingBaseModel>();
            CreateMap<Travely.PropertyManager.API.FilteringBaseModel, Travely.ReportingManager.Services.Models.Base.FilteringBaseModel>();

            CreateMap<CreateToDoItemRequest, AddToDoItemCommand>()
             .ForMember(dest => dest.Deadline, opt => opt
                 .MapFrom(src => src.Deadline.ToDateTime()))
             .ForMember(dest => dest.Reminder, opt => opt
                 .MapFrom(src => src.Deadline.ToDateTime()));

            CreateMap<UpdateToDoItemRequest, EditToDoItemCommand>()
                .ForMember(dest => dest.Deadline, opt => opt
                 .MapFrom(src => src.Deadline.ToDateTime()))
             .ForMember(dest => dest.Reminder, opt => opt
                 .MapFrom(src => src.Deadline.ToDateTime()));

            CreateMap<ToDoItemResponse, GetToDoItemByIdResponse>()
             .ForMember(dest => dest.Deadline, opt => opt
                 .MapFrom(src => Timestamp.FromDateTime(DateTime.SpecifyKind(src.Deadline, DateTimeKind.Utc))))
             .ForMember(dest => dest.Reminder, opt => opt
                 .MapFrom(src => Timestamp.FromDateTime(DateTime.SpecifyKind(src.Reminder ?? DateTime.MinValue, DateTimeKind.Utc)))); ;

            CreateMap<GetUserToDoItemsRequest, GetToDoItemsQuery>();

            CreateMap<ToDoItemResponse, GetUserToDoItemsResponse>()
             .ForMember(dest => dest.Deadline, opt => opt
                 .MapFrom(src => Timestamp.FromDateTime(DateTime.SpecifyKind(src.Deadline, DateTimeKind.Utc))))
             .ForMember(dest => dest.Reminder, opt => opt
                 .MapFrom(src => Timestamp.FromDateTime(DateTime.SpecifyKind(src.Reminder ?? DateTime.MinValue, DateTimeKind.Utc))));
        }
    }
}
