using AutoMapper;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using Travely.Common;
using Travely.ReportingManager.Profiles.Converters;
using Travely.ReportingManager.Protos;
using Travely.ReportingManager.Services.Models.Commands;
using Travely.ReportingManager.Services.Models.Responses;

namespace Travely.ReportingManager.Profiles
{
    public class ToDoMappingProfile : Profile
    {
        public ToDoMappingProfile()
        {
            CreateMap(typeof(RepeatedField<>), typeof(ICollection<>)).ConvertUsing(typeof(RepeatedFieldToCollectionConverter<,>));

            CreateMap<Protos.OrderingModel, Common.OrderingModel>();
            CreateMap<Protos.FilteringModel, Common.FilteringModel>();
            CreateMap<Protos.PagingModel, Common.PagingModel>();


            CreateMap<CreateToDoItemRequest, AddToDoItemCommand>();

            CreateMap<UpdateToDoItemRequest, EditToDoItemCommand>();

            CreateMap<ToDoItemResponse, GetToDoItemByIdResponse>();

            CreateMap<GetUserToDoItemsRequest, DataQueryModel>();

            CreateMap<ToDoItemResponse, GetUserToDoItemsResponse>();
        }
    }
}
