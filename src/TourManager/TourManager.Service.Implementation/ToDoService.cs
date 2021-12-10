using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManager.Clients.Abstraction.ReportingManager;
using TourManager.Service.Abstraction;
using TourManager.Service.Model.ReportingManager;

namespace TourManager.Service.Implementation
{
    public class ToDoService : IToDoService
    {
        private readonly IReportingManagerClient _client;
        public ToDoService(IReportingManagerClient client)
        {
            _client = client;
        }
        public async Task<int> AddAsync(int userId, CreateUpDateToDoItemModel request)
        {
            return await _client.AddToDoItemAsync(userId, request);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteToDoItemAsync(id);
        }

        public async Task<int> EditAsync(int userId, int id, CreateUpDateToDoItemModel request)
        {
            return await _client.EditToDoItemAsync(userId, id, request);
        }

        public Task<IEnumerable<ToDoItemResponeModel>> GetAsync(int userId)
        {
            return _client.GetToDoItemsAsync(userId);
        }

        public Task<ToDoItemResponeModel> GetByIdAsync(int id)
        {
            return _client.GetByIdAsync(id);
        }
    }
}
