using System.Threading.Tasks;
using TourManager.Service.Model;
using System.Collections.Generic;

namespace TourManager.Service.Abstraction
{
    public interface ITourService
    {
        public Task<IEnumerable<Tour>> GetAllTours();
        public Task<Tour> GetTourWithDetails(int tourId);

        public Task CreateTour(Tour tour);
        public Task RemoveTour(Tour tour);
    }
}