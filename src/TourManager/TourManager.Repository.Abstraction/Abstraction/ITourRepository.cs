using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Repository.Entities;

namespace TourManager.Repository.Abstraction
{
    /// <summary>
    /// The tour repository interface
    /// </summary>
    public interface ITourRepository : IRepository<TourEntity>
    {
        /// <summary>
        ///  Get all tours by tenant 
        /// </summary>
        /// <param name="tenantId">The tenant id</param>
        /// <returns></returns>
        Task<List<TourEntity>> GetAll(int tenantId);

        /// <summary>
        /// Get all tours starting from now
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TourEntity>> GetAllFromToday();
    }
}