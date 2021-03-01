using System;
using System.Threading.Tasks;
using Travely.ServiceManager.Abstraction.Interfaces.Repositories;

namespace Travely.ServiceManager.Abstraction.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IActivityRepository ActivityRepository { get; }
        IActivityTypeRepository ActivityTypeRepository { get; }
        Task<int> SaveAsync();
        int Save();
    }
}
