using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Clients.Abstraction.ReportingManager;
using TourManager.Clients.Abstraction.Settings;
using TourManager.Clients.Implementation.Mappers;
using TourManager.Service.Model.ReportingManager;
using Travely.ReportingManager.Protos;

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

        public Task<IEnumerable<ToDoItemResponeModel>> GetToDoItemsAsync(int userId)
        {
            return HandleAsync<IEnumerable<ToDoItemResponeModel>>(async (client) =>
            {
                var toDoItems = new List<ToDoItemResponeModel>();
                var request = new GetUserToDoItemsRequest { UserId = userId };

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
