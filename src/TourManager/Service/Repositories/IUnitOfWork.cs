using System;
using System.Threading.Tasks;

namespace Travely.TourManager.Service.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
