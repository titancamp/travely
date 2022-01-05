using Microsoft.Extensions.Options;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;

namespace Travely.SupplierManager.Grpc.Settings
{
    public class SupplierManagerSettingsProvider : IServiceSettingsProvider<SupplierProto.SupplierProtoClient>
    {
        public SupplierManagerSettingsProvider(IOptions<GrpcSettings<SupplierProto.SupplierProtoClient>> settings)
        {
            Settings = settings.Value;
        }

        public GrpcSettings<SupplierProto.SupplierProtoClient> Settings { get; }
    }
}