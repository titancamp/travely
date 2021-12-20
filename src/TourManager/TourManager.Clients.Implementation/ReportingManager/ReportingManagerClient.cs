using Grpc.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Clients.Abstraction.ReportingManager;
using TourManager.Clients.Abstraction.Settings;
using TourManager.Clients.Implementation.Mappers;
using TourManager.Service.Model.ReportingManager;
using Travely.ReportingManager.Protos;
using Travely.Services.Common.Models;

namespace TourManager.Clients.Implementation.ReportingManager
{
    public class ReportingManagerClient : GrpcClientBase<ToDoItemProtoService.ToDoItemProtoServiceClient>, IReportingManagerClient
    {
        public ReportingManagerClient(IServiceSettingsProvider serviceSettingsProvider)
            : base(serviceSettingsProvider)
        {
        }

        public Task<int> AddToDoItemAsync(int userId, BaseToDoModel model)
        {
            return HandleAsync(async (client) =>
            {
                var request = Mapping.Mapper.Map<CreateToDoItemRequest>(model, opt =>
                    opt.AfterMap((src, dest) => dest.UserId = userId));

                var response = await client.CreateToDoItemAsync(request);

                return response.Id;
            });
        }

        public Task DeleteToDoItemAsync(int id)
        {
            return HandleAsync(async (client) =>
            {
                await client.DeleteToDoItemAsync(new DeleteToDoItemRequest { Id = id });
            });
        }

        public Task<int> EditToDoItemAsync(int userId, int id, BaseToDoModel model)
        {
            return HandleAsync(async (client) =>
            {
                var request = Mapping.Mapper.Map<UpdateToDoItemRequest>(model, opt =>
                    opt.AfterMap((src, dest) =>
                    {
                        dest.Id = id;
                        dest.UserId = userId;
                    }));

                var response = await client.UpdateToDoItemAsync(request);

                return response.Id;
            });
        }

        public Task<ToDoItemResponeModel> GetByIdAsync(int id)
        {
            return HandleAsync(async (client) =>
            {
                var todoitem = await client.GetToDoItemAsync(new GetToDoItemByIdRequest { Id = id });

                return Mapping.Mapper.Map<ToDoItemResponeModel>(todoitem);
            });
        }

        public Task<IEnumerable<ToDoItemResponeModel>> GetToDoItemsAsync(int userId, DataQueryModel queryModel)
        {
            return HandleAsync<IEnumerable<ToDoItemResponeModel>>(async (client) =>
            {
                var toDoItems = new List<ToDoItemResponeModel>();
                var request = new GetUserToDoItemsRequest
                {
                    UserId = userId,
                    Paging = new Travely.ReportingManager.Protos.PagingModel() { Count = queryModel.Paging.Count, From = queryModel.Paging.From }
                };
                foreach (var item in queryModel.Orderings)
                {
                    request.Orderings.Add(new Travely.ReportingManager.Protos.OrderingModel() { FieldName = item.FieldName, IsDescending = item.IsDescending });
                }
                foreach (var item in queryModel.Filters)
                {
                    request.Filters.Add(new Travely.ReportingManager.Protos.FilteringModel { FieldName = item.FieldName, Type = (Travely.ReportingManager.Protos.FilteringOperationType)item.Type, Value = item.Value });
                }
                await foreach (var response in client.GetAllUserToDoItems(request).ResponseStream.ReadAllAsync())
                {
                    toDoItems.Add(Mapping.Mapper.Map<ToDoItemResponeModel>(response));
                }

                return toDoItems;
            });
        }

        protected override ToDoItemProtoService.ToDoItemProtoServiceClient CreateGrpcClient()
        {
            var channel = GetClientGrpcChannel(ServiceSettingsProvider.ComposeReportingServiceUrl());

            return new ToDoItemProtoService.ToDoItemProtoServiceClient(channel);
        }
    }
}
