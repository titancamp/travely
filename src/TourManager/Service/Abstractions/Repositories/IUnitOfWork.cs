using System;
using System.Threading.Tasks;

namespace Travely.TourManager.Abstractions.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
