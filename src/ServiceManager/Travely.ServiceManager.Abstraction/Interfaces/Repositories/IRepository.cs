using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travely.ServiceManager.Abstraction.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(long entityId);
        Task<TEntity> CreateAsync(TEntity entity);
        Task DeleteAsync(long entityId);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
