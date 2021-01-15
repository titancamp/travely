using System;
using System.Threading.Tasks;

namespace Travely.TourManager
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}