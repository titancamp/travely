using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupplierManager.Service.Abstraction
{
    public interface ISupplierService<TModel> where TModel : class
    {
        public Task<List<TModel>> GetAll();
        public Task<TModel> Get(int id);
        public Task<TModel> Create(TModel model);
        public Task<TModel> Update(int id, TModel model);
        public Task Remove(int id);
    }
}