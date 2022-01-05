using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travely.SupplierManager.Grpc.Client.Abstraction
{
    public interface ISupplierManagerClient
    {
        Task<SupplierResponse> CreateSupplierAsync(Supplier supplier);
        Task<SupplierResponse> EditSupplierAsync(Supplier supplier);
        Task<SupplierResponse> DeleteSupplierAsync(long supplierId);
        Task<IEnumerable<Supplier>> GetSuppliersAsync(long agencyId);
    }
}