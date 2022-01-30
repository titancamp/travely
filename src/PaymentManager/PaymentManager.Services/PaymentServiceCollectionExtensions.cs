using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using PaymentManager.Repositories.Entities;
using PaymentManager.Services;

namespace PaymentManager.Extensions.DependencyInjection
{
    public static class PaymentServiceCollectionExtensions
    {
        public static IServiceCollection AddPaymentServices([NotNull] this IServiceCollection serviceCollection)
        {
            serviceCollection.AddPaymentRepositories();
            serviceCollection.AddScoped<IPayableService, PayableService>();
            serviceCollection.AddScoped<IReceivableService, ReceivableService>();
            return serviceCollection;
        }
    }
}