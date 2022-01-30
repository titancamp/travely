using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.Common;
using Travely.ReportingManager.Data;
using Travely.ReportingManager.Data.Models;
using Travely.ReportingManager.Services.Abstractions;
using Travely.ReportingManager.Services.Extensions;
using Travely.ReportingManager.Services.Models.Commands;
using Travely.ReportingManager.Services.Models.Responses;

namespace Travely.ReportingManager.Services.Implementations
{
    public class ToDoItemService : ServiceBase, IToDoItemService
    {
        private readonly ToDoDbContext _dbContext;

        public ToDoItemService(ILogger<ToDoItemService> logger, IMapper mapper, ToDoDbContext toDoDbContext)
            : base(logger, mapper)
        {
            _dbContext = toDoDbContext;
        }
        public async Task<int> AddAsync(long userId, AddToDoItemCommand command)
        {
            var toDoItemModel = Mapper.Map<AddToDoItemCommand, ToDoItemEntity>(command, opt =>
               opt.AfterMap((src, dest) => dest.UserId = userId));

            _dbContext.ToDoItems.Add(toDoItemModel);
            await _dbContext.SaveChangesAsync();

            return toDoItemModel.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var toDoItem = await _dbContext.ToDoItems.FirstOrDefaultAsync(i => i.Id == id);

            _dbContext.ToDoItems.Remove(toDoItem);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> EditAsync(long userId, EditToDoItemCommand command)
        {
            var toDoItem = await _dbContext.ToDoItems.FirstOrDefaultAsync(i=>i.UserId== userId && i.Id==command.Id);

            var toDoItemModel = Mapper.Map(command, toDoItem);

            _dbContext.ToDoItems.Update(toDoItemModel);
            await _dbContext.SaveChangesAsync();

            return toDoItemModel.Id;
        }

        public async Task<IEnumerable<ToDoItemResponse>> GetAsync(long userId, DataQueryModel query)
        {
            var toDoItemsQuery =  _dbContext.ToDoItems.Where(i=>i.UserId==userId).AsQueryable();

            toDoItemsQuery = toDoItemsQuery.FilterBy(query.Filters);
            toDoItemsQuery = toDoItemsQuery.OrderBy(query.Orderings);
            toDoItemsQuery = toDoItemsQuery.Paginate(query.Paging);

            var toDoItems = await toDoItemsQuery.AsNoTracking().ToListAsync();

            return Mapper.Map<IEnumerable<ToDoItemEntity>, IEnumerable<ToDoItemResponse>>(toDoItems);
        }

        public async Task<ToDoItemResponse> GetByIdAsync(int id)
        {
            var property = await _dbContext.ToDoItems.FirstOrDefaultAsync(i => i.Id == id); 

            return Mapper.Map<ToDoItemResponse>(property);
        }
    }
}
