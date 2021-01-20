using System;
using System.Threading.Tasks;
using Travely.TourManager.Abstractions.Repositories;

namespace Travely.TourManager.Repository
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
