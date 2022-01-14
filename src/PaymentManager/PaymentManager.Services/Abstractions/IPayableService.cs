using PaymentManager.Repositories.Entities;
using PaymentManager.Services.Models;
using PaymentManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Services
{
    public interface IPayableService
    {
        PayablePage Get(int agencyId, PaymentQueryParameters parameters);
        Task<PayableRead> GetAsync(int agencyId, int id);
        Task<PayableRead> CreateAsync(int agencyId, PayableCreate model);
        Task CreateRangeAsync(int agencyId, List<PayableCreate> models);
        Task<PayableRead> UpdateAsync(int agencyId, int id, PayableUpdate model);
        Task UpdateSupplier(int agencyId, int id, PayableSupplierUpdate model);
        Task UpdatePayablesTourStatus(int agencyId, int tourId, int tourStatus);
        Task DeleteSupplierFromPayable(int agencyId, int tourId, int supplierId);
        Task<List<PayableRead>> Find(Expression<Func<PayableEntity, bool>> predicate);
    }
}
