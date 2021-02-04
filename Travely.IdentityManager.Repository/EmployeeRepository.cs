using Travely.IdentityManager.IRepository;
using Travely.IdentityManager.Repository.Model.AppEntities;
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
