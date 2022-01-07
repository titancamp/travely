using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.SupplierManager.API.Models;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.Service
{
    public interface ISupplierService<TModel> where TModel : class
    {
        public Task<SupplierPage<TModel>> Get(int agencyId, SupplierQueryParams parameters);
        public Task<List<TModel>> GetAll(int agencyId);
        public Task<TModel> Get(int agencyId, int id);
        public Task<TModel> Create(int agencyId, TModel model);
        public Task<TModel> Update(int agencyId, int id, TModel model);
        public Task Remove(int agencyId, int id);
    }
}