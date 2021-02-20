using Travely.IdentityManager.Repository.Abstractions;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace Travely.IdentityManager.Repository.EntityFramework
{
    public class EmployeeRepository : BaseRepository<Employee, IdentityServerDbContext>, IEmployeeRepository
    {
        public EmployeeRepository(IdentityServerDbContext identityServerDbContext) : base(identityServerDbContext)
        {

        }
    }
}
