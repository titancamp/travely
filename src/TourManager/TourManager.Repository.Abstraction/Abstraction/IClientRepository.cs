using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Repository.Entities;

namespace TourManager.Repository.Abstraction
{
    /// <summary>
    /// The client repository interface
    /// </summary>
    public interface IClientRepository : IRepository<TourClientEntity>
    {
        /// <summary>
        ///  Get all clients of a tour
        /// </summary>
        /// <param name="tourId">The tour id</param>
        /// <returns></returns>
        Task<List<TourClientEntity>> GetAll(int tourId);
    }
}