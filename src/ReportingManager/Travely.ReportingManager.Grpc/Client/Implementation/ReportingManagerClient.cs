using AutoMapper;
using Grpc.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.Common;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;
using Travely.ReportingManager.Grpc.Client.Abstraction;
using Travely.ReportingManager.Grpc.Models;
using Travely.ReportingManager.Protos;

namespace Travely.ReportingManager.Grpc.Client.Implementation
{
    public class ReportingManagerClient : GrpcClientBase<ToDoItemProtoService.ToDoItemProtoServiceClient>, IReportingManagerClient
    {
        private readonly IMapper _mapper;

        public ReportingManagerClient(
            IServiceSettingsProvider<ToDoItemProtoService.ToDoItemProtoServiceClient> serviceSettingsProvider,
            IMapper mapper)
            : base(serviceSettingsProvider)
        {
            _mapper = mapper;
        }

        public Task<int> AddToDoItemAsync(int userId, BaseToDoModel model)
        {
            return HandleAsync(async (client) =>
            {
                var request = _mapper.Map<CreateToDoItemRequest>(model, opt =>
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
                var request = _mapper.Map<UpdateToDoItemRequest>(model, opt =>
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

                return _mapper.Map<ToDoItemResponeModel>(todoitem);
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
                    Paging = new Protos.PagingModel() { Count = queryModel.Paging.Count, From = queryModel.Paging.From }
                };
                foreach (var item in queryModel.Orderings)
                {
                    request.Orderings.Add(new Protos.OrderingModel() { FieldName = item.FieldName, IsDescending = item.IsDescending });
                }
                foreach (var item in queryModel.Filters)
                {
                    request.Filters.Add(new Protos.FilteringModel { FieldName = item.FieldName, Type = (Protos.FilteringOperationType) item.Type, Value = item.Value });
                }
                await foreach (var response in client.GetAllUserToDoItems(request).ResponseStream.ReadAllAsync())
                {
                    toDoItems.Add(_mapper.Map<ToDoItemResponeModel>(response));
                }

                return toDoItems;
            });
        }
    }
}
