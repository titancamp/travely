using System.Threading.Tasks;
using Travely.ServiceManager.Abstraction.Interfaces;
using Travely.ServiceManager.Abstraction.Interfaces.UnitOfWorks;
using Travely.ServiceManager.DAL.Data;
using Travely.ServiceManager.DAL.Repositories;

namespace Travely.ServiceManager.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ServiceManagerDbContext _dbContext;
        private ActivityRepository _serviceRepository;
        public UnitOfWork(ServiceManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActivityRepository ServiceEntities
        {
            get
            {
                if (_serviceRepository == null)
                 _serviceRepository = new ActivityRepository(_dbContext);
                
                return _serviceRepository;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public Task<int> SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
