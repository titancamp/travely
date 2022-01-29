using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.SupplierManager.API.Models;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.Service
{
    public interface ISupplierService<TModel, in TFilter>
        where TModel : class
        where TFilter : class
    {
        public SupplierPage<TModel> Get(int agencyId, SupplierQueryParams parameters, TFilter filters);
        public Task<TModel> GetAsync(int agencyId, int id);
        public Task<TModel> CreateAsync(int agencyId, TModel model);
        public Task<TModel> UpdateAsync(int agencyId, int id, TModel model);
        public Task RemoveAsync(int agencyId, int id);
    }
}