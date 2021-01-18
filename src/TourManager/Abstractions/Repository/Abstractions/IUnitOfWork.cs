using System;
using System.Threading.Tasks;

namespace Travely.TourManager.Repository.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
