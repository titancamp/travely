using AutoMapper;
using Grpc.Core;
using System.Threading.Tasks;
using Travely.ReportingManager.Protos;
using Travely.ReportingManager.Services.Abstractions;
using Travely.ReportingManager.Services.Models.Commands;
using Travely.ReportingManager.Services.Models.Responses;
using Travely.Services.Common.Models;

namespace Travely.ReportingManager.Services
{
    public class ToDoService : ToDoItemProtoService.ToDoItemProtoServiceBase
    {
        private readonly IToDoItemService _toDoItemService;

        private readonly IMapper _mapper;
       // private readonly ILogger<ToDoService> _logger;

        public ToDoService(
           
            IToDoItemService toDoItemService,
            IMapper mapper
       )
        {
            _toDoItemService = toDoItemService;
            _mapper = mapper;

        }

        public override async Task<CreateToDoItemResponse> CreateToDoItem(CreateToDoItemRequest request, ServerCallContext context)
        {
            var command = _mapper.Map<CreateToDoItemRequest, AddToDoItemCommand>(request);
            var resultId = await _toDoItemService.AddAsync(request.UserId, command);

            return new CreateToDoItemResponse { Id = resultId };
        }

        public override async Task<UpdateToDoItemResponse> UpdateToDoItem(UpdateToDoItemRequest request, ServerCallContext context)
        {
            //TODO validate
            var command = _mapper.Map<UpdateToDoItemRequest, EditToDoItemCommand>(request);
            var resultId = await _toDoItemService.EditAsync(request.UserId, command);

            return new UpdateToDoItemResponse { Id = resultId };
        }

        public override async Task<DeleteToDoItemResponse> DeleteToDoItem(DeleteToDoItemRequest request, ServerCallContext context)
        {
            await _toDoItemService.DeleteAsync(request.Id);

            return new DeleteToDoItemResponse();
        }

        public override async Task<GetToDoItemByIdResponse> GetToDoItem(GetToDoItemByIdRequest request, ServerCallContext context)
        {
            var result = await _toDoItemService.GetByIdAsync(request.Id);

            return _mapper.Map<GetToDoItemByIdResponse>(result);
        }

        public override async Task GetAllUserToDoItems(GetUserToDoItemsRequest request, IServerStreamWriter<GetUserToDoItemsResponse> responseStream, ServerCallContext context)
        {
            var query = _mapper.Map<GetUserToDoItemsRequest, DataQueryModel>(request);
            var result = await _toDoItemService.GetAsync(request.UserId, query);

            foreach (var row in result)
            {
                await responseStream.WriteAsync(_mapper.Map<ToDoItemResponse, GetUserToDoItemsResponse>(row));
            }
        }
    }
}