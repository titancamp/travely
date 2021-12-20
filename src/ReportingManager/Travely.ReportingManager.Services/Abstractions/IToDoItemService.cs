using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.ReportingManager.Services.Models.Commands;
using Travely.ReportingManager.Services.Models.Responses;
using Travely.Services.Common.Models;

namespace Travely.ReportingManager.Services.Abstractions
{
    public interface IToDoItemService
    {
        Task<int> AddAsync(long userId, AddToDoItemCommand command);

        Task<int> EditAsync(long userId, EditToDoItemCommand command);

        Task DeleteAsync(int id);

        Task<ToDoItemResponse> GetByIdAsync(int id);

        Task<IEnumerable<ToDoItemResponse>> GetAsync(long userId, DataQueryModel query);
    }
}
