using AutoMapper;
using Travely.ReportingManager.Data.Models;
using Travely.ReportingManager.Services.Models.Commands;
using Travely.ReportingManager.Services.Models.Responses;

namespace Travely.ReportingManager.Services.MappingProfiles
{
    public class ToDoMappingProfile : Profile
    {
        public ToDoMappingProfile()
        {
            CreateMap<AddToDoItemCommand, ToDoItemEntity>();
            CreateMap<EditToDoItemCommand, ToDoItemEntity>();
            CreateMap<ToDoItemEntity, ToDoItemResponse>();
        }

    }
}
