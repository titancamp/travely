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
    public interface IReceivableService
    {
        ReceivablePage Get(int agencyId, PaymentQueryParameters parameters);
        Task<ReceivableRead> GetAsync(int agencyId, int id);
        Task<ReceivableRead> CreateAsync(int agencyId, ReceivableCreate model);
        Task CreateRangeAsync(int agencyId, List<ReceivableCreate> models);
        Task<ReceivableRead> UpdateAsync(int agencyId, int id, ReceivableUpdate model);
        Task<List<ReceivableRead>> Find(Expression<Func<ReceivableEntity, bool>> predicate);
    }
}
