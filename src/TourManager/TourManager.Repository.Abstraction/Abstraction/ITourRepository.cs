using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Repository.Entities;
using TourManager.Repository.Models;

namespace TourManager.Repository.Abstraction
{
    /// <summary>
    /// The tour repository interface
    /// </summary>
    public interface ITourRepository : IRepository<TourEntity>
    {
        /// <summary>
        /// Gets tour by identifier.
        /// </summary>
        /// <param name="id">The tour identifier.</param>
        /// <param name="includeBookings">If true includes bookings.</param>
        /// <param name="includeClients">If true includes clients.</param>
        /// <returns></returns>
        public Task<TourEntity> GetByIdAsync(int id, bool includeBookings, bool includeClients);

        /// <summary>
        /// Get tours
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <returns></returns>
        Task<List<TourEntity>> Get(GetTourFilter filter);
    }
}