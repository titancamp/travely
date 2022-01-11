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
        Task<PayablePage> Get(int agencyId, PaymentQueryParameters parameters);
        Task<PayableRead> Get(int agencyId, int id);
        Task<PayableRead> Create(int agencyId, PayableCreate model);
        Task CreateRange(int agencyId, List<PayableCreate> models);
        Task<PayableRead> Update(int agencyId, int id, PayableUpdate model);
        Task UpdateSupplier(int agencyId, int id, PayableSupplierUpdate model);
        Task UpdatePayablesTourStatus(int agencyId, int tourId, int tourStatus);
        Task DeleteSupplierFromPayable(int agencyId, int tourId, int supplierId);
        Task Remove(int agencyId, int id);
        Task<List<PayableRead>> Find(Expression<Func<PayableEntity, bool>> predicate);
    }
}
