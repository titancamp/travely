using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.Common;
using Travely.ReportingManager.Grpc.Models;

namespace Travely.ReportingManager.Grpc.Client.Abstraction
{
    public interface IReportingManagerClient
    {
        Task<int> AddToDoItemAsync(int userId, BaseToDoModel model);

        Task<int> EditToDoItemAsync(int userId, int id, BaseToDoModel model);

        Task DeleteToDoItemAsync(int id);

        Task<ToDoItemResponeModel> GetByIdAsync(int id);

        Task<IEnumerable<ToDoItemResponeModel>> GetToDoItemsAsync(int userId, DataQueryModel dataQuery);

    }
}
