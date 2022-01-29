using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using PaymentManager.Repositories;
using PaymentManager.Repositories.Entities;

namespace PaymentManager.Extensions.DependencyInjection
{
    public static class PaymentRepositoryCollectionExtensions
    {
        public static IServiceCollection AddPaymentRepositories([NotNull] this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPaymentRepository<PayableEntity>, PayableRepository>();
            serviceCollection.AddScoped<IPaymentRepository<ReceivableEntity>, ReceivableRepository>();
            return serviceCollection;
        }
    }
}