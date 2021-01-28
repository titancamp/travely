using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.ServiceManager.Core.Models.Db;

namespace Travely.ServiceManager.Core.Interfaces
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
