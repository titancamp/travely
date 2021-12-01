using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManager.Service.Model.ReportingManager;

namespace TourManager.Clients.Abstraction.ReportingManager
{
    public interface IReportingManagerClient
    {
        Task<ToDoItemResponeModel> GetToDoItemAsync(int itemId);
        Task<IEnumerable<ToDoItemResponeModel>> GetUserAllToDoItemsAsync(int userId);
        Task<ToDoItemResponeModel> CreateToDoItemAsync(CreateToDoItemModel toDoItem);
        Task<ToDoItemResponeModel> EditToDoItemAsync(CreateToDoItemModel toDoItem);
        Task<bool> DeleteToDoItemAsync(int itemId);
    }
}
