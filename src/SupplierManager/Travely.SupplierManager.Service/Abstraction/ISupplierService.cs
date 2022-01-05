using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travely.SupplierManager.Service
{
    public interface ISupplierService<TModel> where TModel : class
    {
        public Task<List<TModel>> GetAll(int agencyId);
        public Task<TModel> Get(int agencyId, int id);
        public Task<TModel> Create(int agencyId, TModel model);
        public Task<TModel> Update(int agencyId, int id, TModel model);
        public Task Remove(int agencyId, int id);
    }
}