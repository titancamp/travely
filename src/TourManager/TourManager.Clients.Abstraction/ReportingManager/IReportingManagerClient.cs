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
        Task<int> AddToDoItemAsync(int userId, CreateUpDateToDoItemModel model);

        Task<int> EditToDoItemAsync(int userId, int id, CreateUpDateToDoItemModel model);

        Task DeleteToDoItemAsync(int id);

        Task<ToDoItemResponeModel> GetByIdAsync(int id);

        Task<IEnumerable<ToDoItemResponeModel>> GetToDoItemsAsync(int userId);

    }
}
