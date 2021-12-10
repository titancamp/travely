using AutoMapper;
using TourManager.Service.Model.ReportingManager;
using Travely.ReportingManager.Protos;

namespace TourManager.Clients.Implementation.Mappers
{
    public class ReporingClientProfile : Profile
    {
        public ReporingClientProfile()
        {
            CreateMap<CreateUpDateToDoItemModel, CreateToDoItemRequest>();
            CreateMap<CreateUpDateToDoItemModel, UpdateToDoItemRequest>();
            CreateMap<GetToDoItemByIdResponse, ToDoItemResponeModel>();
            CreateMap<GetUserToDoItemsResponse, ToDoItemResponeModel>();
        }
    }
}
