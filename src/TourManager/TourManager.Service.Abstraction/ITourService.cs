using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Service.Model;

namespace TourManager.Service.Abstraction
{
    /// <summary>
    /// The tour service interface
    /// </summary>
    public interface ITourService
    {
        /// <summary>
        /// Get tour by agency Id
        /// </summary>
        /// <param name="agencyId">The agency id</param>
        /// <returns></returns>
        public Task<List<Tour>> GetTours(int agencyId);

        /// <summary>
        /// Get specific tour by id 
        /// </summary>
        /// <param name="tourId">The tour id</param>
        /// <returns></returns>
        public Task<Tour> GetTourById(int agencyId, int tourId);

        /// <summary>
        /// Create new tour
        /// </summary>
        /// <param name="tour">The tour to create</param>
        /// <returns></returns>
        public Task<Tour> CreateTour(int agencyId, Tour tour);

        /// <summary>
        /// Update the specific tour
        /// </summary>
        /// <param name="tour">The tour to update</param>
        /// <returns></returns>
        public Task<Tour> UpdateTour(int agencyId, int id, Tour tour);

        /// <summary>
        /// Remove specific tour by id
        /// </summary>
        /// <param name="tourId">The tour id to remove</param>
        /// <returns></returns>
        public Task RemoveTour(int agencyId, int tourId);
    }
}