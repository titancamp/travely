using Travely.IdentityManager.Repository.Abstractions;
using Travely.IdentityManager.Repository.Abstractions.Entities;
using Travely.IdentityManager.Repository.Model.Context;

namespace Travely.IdentityManager.Repository
{
    public class EmployeeRepository : BaseRepository<Employee, IdentityServerDbContext>, IEmployeeRepository
    {
        public EmployeeRepository(IdentityServerDbContext identityServerDbContext) : base(identityServerDbContext)
        {

        }
    }
}
