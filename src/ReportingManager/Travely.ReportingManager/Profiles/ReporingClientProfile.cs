using AutoMapper;
using Travely.ReportingManager.Grpc.Models;
using Travely.ReportingManager.Protos;

namespace TourManager.Clients.Implementation.Mappers
{
    public class ReporingClientProfile : Profile
    {
        public ReporingClientProfile()
        {
            CreateMap<BaseToDoModel, CreateToDoItemRequest>();
            CreateMap<BaseToDoModel, UpdateToDoItemRequest>();

            CreateMap<GetToDoItemByIdResponse, ToDoItemResponeModel>();
            CreateMap<GetUserToDoItemsResponse, ToDoItemResponeModel>();
        }
    }
}
