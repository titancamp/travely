using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using PaymentManager.Repositories.Entities;
using PaymentManager.Services;
using PaymentManager.Services.Helpers;

namespace PaymentManager.Extensions.DependencyInjection
{
    public static class PaymentServiceCollectionExtensions
    {
        public static IServiceCollection AddPaymentServices([NotNull] this IServiceCollection serviceCollection)
        {
            serviceCollection.AddPaymentRepositories();
            serviceCollection.AddScoped<IPayableService, PayableService>();
            serviceCollection.AddScoped<IReceivableService, ReceivableService>();
            serviceCollection.AddSingleton<ISortHelper<PayableEntity>, SortHelper<PayableEntity>>();
            serviceCollection.AddSingleton<ISortHelper<ReceivableEntity>, SortHelper<ReceivableEntity>>();
            serviceCollection.AddSingleton<ISearchHelper<PayableEntity>, PayableSearchHelper>();
            serviceCollection.AddSingleton<ISearchHelper<ReceivableEntity>, ReceivableSearchHelper>();
            return serviceCollection;
        }
    }
}