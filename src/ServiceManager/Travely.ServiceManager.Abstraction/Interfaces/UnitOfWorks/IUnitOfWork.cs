using System;
using System.Threading.Tasks;

namespace Travely.ServiceManager.Abstraction.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IActivityRepository Activities { get; }
        Task<int> SaveAsync();
    }
}
