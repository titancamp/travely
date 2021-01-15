using System;
using System.Threading.Tasks;

namespace Travely_TourManager
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}