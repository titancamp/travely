using System;
using System.Threading.Tasks;

namespace Travely.ServiceManager.Core.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IActivityRepository ServiceEntities { get; }
        Task<int> SaveAsync();
    }
}
