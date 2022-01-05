using PaymentManager.Services.Models;
using PaymentManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Services
{
    public interface IReceivableService
    {
        Task<ReceivablePage> Get(int agencyId, PaymentQueryParameters parameters);
        Task<ReceivableRead> Get(int agencyId, int id);
        Task<ReceivableRead> Create(int agencyId, ReceivableCreate model);
        Task CreateRange(int agencyId, List<ReceivableCreate> models);
        Task<ReceivableRead> Update(int agencyId, int id, ReceivableUpdate model);
        Task Remove(int agencyId, int id);
    }
}
