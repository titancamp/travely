using System;
using System.Threading.Tasks;

namespace Travely.IdentityManager.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IAgencyRepository AgencyRepository { get; }
        IEmployeeRepository EmployeeDataRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
