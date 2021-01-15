using System;
using System.Threading.Tasks;

namespace Travely_TourManager.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
