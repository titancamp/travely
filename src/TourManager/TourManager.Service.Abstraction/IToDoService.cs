using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManager.Service.Model.ReportingManager;

namespace TourManager.Service.Abstraction
{
    public interface IToDoService
    {
        Task<int> AddAsync(int userId, BaseToDoModel request);

        Task<int> EditAsync(int userId, int id, BaseToDoModel request);

        Task DeleteAsync(int id);

        Task<ToDoItemResponeModel> GetByIdAsync(int id);

        Task<IEnumerable<ToDoItemResponeModel>> GetAsync(int userId);
    }
}
