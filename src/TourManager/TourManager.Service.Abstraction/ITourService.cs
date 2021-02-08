using System.Threading.Tasks;
using TourManager.Service.Model;
using System.Collections.Generic;

namespace TourManager.Service.Abstraction
{
    public interface ITourService
    {
        public Task<List<Tour>> GetTours(int tenantId);
        public Task<Tour> GetTourById(int tourId);
        public Task CreateTour(Tour tour);
        public Task UpdateTour(Tour tour);
        public Task RemoveTour(int tourId);
    }
}