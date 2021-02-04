using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Travely.IdentityManager.IRepository;
using Travely.IdentityManager.Repository.Model.Context;

namespace Travely.IdentityManager.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IEmployeeRepository _employeeRepository;
        private IAgencyRepository _agencyRepository;
        private IUserRepository _userRepository;

        private DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEmployeeRepository EmployeeDataRepository
        {
            get
            {
                if (_dbContext != null)
                {
                    _employeeRepository = new EmployeeRepository(_dbContext as IdentityServerDbContext);
                }
                return _employeeRepository;
            }
        }

        public IAgencyRepository AgencyRepository
        {
            get
            {
                if (_dbContext != null)
                {
                    _agencyRepository = new AgencyRepository(_dbContext as IdentityServerDbContext);
                }
                return _agencyRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_dbContext != null)
                {
                    _userRepository = new UserRepository(_dbContext as IdentityServerDbContext);
                }
                return _userRepository;
            }
        }
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _dbContext.SaveChangesAsync(); 
            }
            catch (Exception)
            {
                throw;
            }
        }




        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    if (_dbContext != null)
                    {
                        _dbContext.Dispose();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                _dbContext = null;
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~UnitOfWork()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
