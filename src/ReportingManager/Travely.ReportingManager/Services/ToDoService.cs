using AutoMapper;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.ReportingManager.Data.Models;
using Travely.ReportingManager.Helpers;
using Travely.ReportingManager.Protos;
using Travely.ReportingManager.Services.Abstractions;
using Travely.Services.Common.CustomExceptions;

namespace Travely.ReportingManager.Services
{
    public class ToDoService : ToDoItemProtoService.ToDoItemProtoServiceBase
    {
        private readonly IToDoItemService _toDoItemService;

        private readonly IMapper _mapper;
        private readonly IFilter<ToDoItemEntity> _filter;
        private readonly ILogger<ToDoService> _logger;

        public ToDoService(
            ILogger<ToDoService> logger,
            IToDoItemService toDoItemService,
            IMapper mapper,
            IFilter<ToDoItemEntity> filter)
        {
            _logger = logger;
            _toDoItemService = toDoItemService;
            _mapper = mapper;
            _filter = filter;
        }

        public override async Task<ToDoItemModel> GetToDoItem(GetToDoItemRequest request, ServerCallContext context)
        {
            ToDoItemEntity item = await _toDoItemService.GetById(request.Id);

            if (item == null)
            {
                throw new NotFoundException(nameof(ToDoItemEntity), request.Id);
            }

            ToDoItemModel itemModel = _mapper.Map<ToDoItemModel>(item);

            return itemModel;
        }

        public override async Task<ToDoItems> GetAllUserToDoItems(GetUserToDoItemsRequest request, ServerCallContext context)
        {
            IEnumerable<ToDoItemEntity> list = await _toDoItemService.GetWhere(_filter.ToPredicate(request.Filters));

            ToDoItems todoItems = _mapper.Map<ToDoItems>(list);

            return todoItems;
        }
    }
}