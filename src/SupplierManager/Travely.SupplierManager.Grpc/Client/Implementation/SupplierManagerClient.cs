using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;
using Travely.SupplierManager.Grpc.Client.Abstraction;

namespace Travely.SupplierManager.Grpc.Client.Implementation
{
    public class SupplierManagerClient : GrpcClientBase<SupplierProto.SupplierProtoClient>, ISupplierManagerClient
    {
        public SupplierManagerClient(
            IServiceSettingsProvider<SupplierProto.SupplierProtoClient> serviceSettingsProvider)
            : base(serviceSettingsProvider)
        {
        }

        public Task<SupplierResponse> CreateSupplierAsync(Supplier supplier)
        {
            return HandleAsync(async client =>
            {
                var response = await client.CreateSupplierAsync(supplier);
                return response;
            });
        }

        public Task<SupplierResponse> EditSupplierAsync(Supplier supplier)
        {
            return HandleAsync(async client =>
            {
                var response = await client.EditSupplierAsync(supplier);
                return response;
            });
        }

        public Task<SupplierResponse> DeleteSupplierAsync(long SupplierId)
        {
            return HandleAsync(async client =>
            {
                var response = await client.DeleteSupplierAsync(new DeleteSupplierRequest
                {
                    SupplierId = SupplierId
                });
                return response;
            });
        }

        public Task<IEnumerable<Supplier>> GetSuppliersAsync(long AgencyId)
        {
            return HandleAsync(async client =>
            {
                var suppliers = await client.GetSuppliersAsync(new GetSuppliersRequest
                {
                    AgencyId = AgencyId
                });

                return suppliers.Suppliers_.Select(s => s);
            });
        }
    }
}