using System;
using System.Threading;
using System.Threading.Tasks;

namespace Travely.IdentityManager.Repository.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancaletionToken = default);
    }
}
