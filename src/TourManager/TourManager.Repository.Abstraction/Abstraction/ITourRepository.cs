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
        /// Get tours
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <returns></returns>
        Task<List<TourEntity>> Get(GetTourFilter filter);
    }
}