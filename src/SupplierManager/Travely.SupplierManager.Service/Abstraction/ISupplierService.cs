using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.SupplierManager.API.Models;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.Service
{
    public interface ISupplierService<TModel> where TModel : class
    {
        public SupplierPage<TModel> Get(int agencyId, SupplierQueryParams parameters);
        public List<TModel> GetAll(int agencyId);
        public Task<TModel> GetAsync(int agencyId, int id);
        public Task<TModel> CreateAsync(int agencyId, TModel model);
        public Task<TModel> UpdateAsync(int agencyId, int id, TModel model);
        public Task RemoveAsync(int agencyId, int id);
    }
}