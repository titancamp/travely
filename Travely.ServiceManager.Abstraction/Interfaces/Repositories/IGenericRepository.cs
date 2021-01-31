using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.ServiceManager.Abstraction.Models.Db;

namespace Travely.ServiceManager.Abstraction.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int entityId);
        Task<TEntity> CreateAsync(TEntity entity);
        Task DeleteAsync(int entityId);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
