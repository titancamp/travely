using AutoMapper;
using System.Collections.Generic;
using Travely.ReportingManager.Data.Models;
using Travely.ReportingManager.Protos;

namespace Travely.ReportingManager.Profiles
{
    class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDoItemEntity, ToDoItemModel>();
            CreateMap<IEnumerable<ToDoItemEntity>, ToDoItems>()
                .ForMember(m => m.Items, opt => opt.MapFrom(m => m));
        }
    }
}
