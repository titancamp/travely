using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travely.Common.Grpc;
using Travely.PaymentManager.Grpc;

namespace PaymentManager.Extensions.DependencyInjection
{
    public static class PaymentGrpcServiceCollectionExtensions
    {
        public static IServiceCollection AddPaymentGrpcServices([NotNull] this IServiceCollection serviceCollection, IConfiguration Configuration)
        {
            serviceCollection.AddGrpc();
            serviceCollection.Configure<GrpcSettings<PaymentProto.PaymentProtoClient>>(Configuration.GetSection("PayableGrpcService"));
            serviceCollection.Configure<GrpcSettings<ReceivableProto.ReceivableProtoClient>>(Configuration.GetSection("ReceivableGrpcService"));

            return serviceCollection;
        }
    }
}
