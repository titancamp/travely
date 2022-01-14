using Microsoft.Extensions.Options;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;
using Travely.PaymentManager.Grpc;

namespace PaymentManager.Grpc.Settings
{
    public class PaymentManagerSettingsProvider : IServiceSettingsProvider<PaymentProto.PaymentProtoClient>
    {
        public PaymentManagerSettingsProvider(IOptions<GrpcSettings<PaymentProto.PaymentProtoClient>> settings)
        {
            Settings = settings.Value;
        } 

        public GrpcSettings<PaymentProto.PaymentProtoClient> Settings { get; }
    }
}
