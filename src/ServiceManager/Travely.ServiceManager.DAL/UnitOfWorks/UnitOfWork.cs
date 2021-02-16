using System.Threading.Tasks;
using Travely.ServiceManager.Abstraction.Interfaces;
using Travely.ServiceManager.Abstraction.Interfaces.Repositories;
using Travely.ServiceManager.Abstraction.Interfaces.UnitOfWorks;
using Travely.ServiceManager.DAL.Repositories;

namespace Travely.ServiceManager.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ServiceManagerDbContext _dbContext;
        private ActivityRepository _activityRepository;
        private ActivityTypeRepository _activityTypeRepository;
        public UnitOfWork(ServiceManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActivityRepository Activities
        {
            get
            {
                if (_activityRepository == null)
                    _activityRepository = new ActivityRepository(_dbContext);

                return _activityRepository;
            }
        }

        public IActivityTypeRepository ActivityTypes
        {
            get
            {
                if (_activityTypeRepository == null)
                    _activityTypeRepository = new ActivityTypeRepository(_dbContext);

                return _activityTypeRepository;
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
