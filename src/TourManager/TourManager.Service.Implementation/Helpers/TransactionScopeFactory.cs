using System.Transactions;

namespace TourManager.Service.Implementation.Helpers
{
    public class TransactionScopeFactory
    {
        public static TransactionScope CreateAsyncReadCommittedTransactionScope()
        {
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            };

            return new TransactionScope(
                TransactionScopeOption.Required,
                transactionOptions,
                TransactionScopeAsyncFlowOption.Enabled);
        }
    }
}
