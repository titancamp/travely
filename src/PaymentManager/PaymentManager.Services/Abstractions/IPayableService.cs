using PaymentManager.Services.Models;
using PaymentManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Services
{
    public interface IPayableService
    {
        Task<PayablePage> Get(int agencyId, PayableQueryParameters parameters);
        Task<PayableRead> Get(int agencyId, int id);
        Task<PayableRead> Create(int agencyId, PayableCreate model);
        Task CreateRange(int agencyId, List<PayableCreate> models);
        Task<PayableRead> Update(int agencyId, int id, PayableUpdate model);
        Task Remove(int agencyId, int id);
    }
}
