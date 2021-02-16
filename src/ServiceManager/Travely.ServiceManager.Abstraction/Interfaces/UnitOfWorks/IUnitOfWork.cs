using System;
using System.Threading.Tasks;
using Travely.ServiceManager.Abstraction.Interfaces.Repositories;

namespace Travely.ServiceManager.Abstraction.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IActivityRepository Activities { get; }
        IActivityTypeRepository ActivityTypes { get; }
        Task<int> SaveAsync();
    }
}
