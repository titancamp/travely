using PaymentManager.Grpc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.PaymentManager.Grpc;

namespace PaymentManager.Grpc.Clients.Abstraction
{
    public interface IPaymentManagerClient
    {
        Task<List<int>> AddPayableAsync(int agencyId, IEnumerable<AddPaymentModel> model);

        Task<SupplierUpdateResponseModel> UpdateSupplierAsync(int agencyId, int id, UpdateSupplierModel model);

        Task<List<PayablesByTourIdEntity>> GetPayablesByTourId(int agencyId, TourEntity model);

        Task<List<PayableReadEntity>> GetPayablesByAgencyId(PayablesByAgencyEntity model);
    }
}
