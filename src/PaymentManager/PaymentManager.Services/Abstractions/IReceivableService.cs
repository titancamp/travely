using PaymentManager.Services.Models;
using PaymentManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentManager.Repositories.Filters;
using PaymentManager.Repositories.Models;

namespace PaymentManager.Services
{
    public interface IReceivableService
    {
        ReceivablePage Get(int agencyId, PaymentQueryParameters parameters, ReceivableFilter receivableFilter);
        Task<ReceivableRead> GetAsync(int agencyId, int id);
        Task<ReceivableRead> CreateAsync(int agencyId, ReceivableCreate model);
        Task CreateRangeAsync(int agencyId, List<ReceivableCreate> models);
        Task<ReceivableRead> UpdateAsync(int agencyId, int id, ReceivableUpdate model);
    }
}
