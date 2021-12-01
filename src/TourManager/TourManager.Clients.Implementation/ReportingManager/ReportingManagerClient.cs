using System;
using System.Threading.Tasks;
using TourManager.Clients.Abstraction.Settings;
using TourManager.Service.Model.ReportingManager;
using Travely.ReportingManager.Protos;

namespace TourManager.Clients.Implementation.ReportingManager
{
    //ToDo mapping 
    //Implement interface
    class ReportingManagerClient : GrpcClientBase<ToDoItemProtoService.ToDoItemProtoServiceClient>
    {
        public ReportingManagerClient(IServiceSettingsProvider serviceSettingsProvider)
            : base(serviceSettingsProvider)
        {
        }
        public Task<ToDoItemModel> CreateToDoItemAsync(CreateToDoItemModel toDoItem)
        {
            return HandleAsync(async (client) =>
            {
                var request = new CreateToDoItemRequest();
                var response = await client.CreateToDoItemAsync(request);

                return response;
            });
        }

        public Task<bool> DeleteToDoItemAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoItemResponeModel> EditToDoItemAsync(CreateToDoItemModel toDoItem)
        {
            throw new NotImplementedException(); 
        }

        public Task<ToDoItemModel> GetToDoItemAsync(int itemId)
        {
            return HandleAsync(async (client) =>
            {
                var request = new GetToDoItemRequest();
                var response = await client.GetToDoItemAsync(request);

                return response;
            });
        }

        public Task<ToDoItems> GetUserAllToDoItemsAsync(int userId)
        {
            return HandleAsync(async (client) =>
            {
                var request = new GetUserToDoItemsRequest();
                var response = await client.GetAllUserToDoItemsAsync(request);

                return response;
            });
        }

        protected override ToDoItemProtoService.ToDoItemProtoServiceClient CreateGrpcClient()
        {
            var channel = GetClientGrpcChannel(ServiceSettingsProvider.ComposeReportingServiceUrl());

            return new ToDoItemProtoService.ToDoItemProtoServiceClient(channel);
        }
    }
}
