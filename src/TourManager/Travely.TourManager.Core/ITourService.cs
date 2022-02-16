using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.TourManager.Core.Details;

namespace Travely.TourManager.Core
{
    public interface ITourService
    {
        Task<CreateTourResponse> CreateTourAsync(TourDataRequest model);

        Task<TourDataResponse> GetTourByIdAsync(int id);

        Task UpdateTourAsync(int id, TourDataRequest model);

        Task<IEnumerable<TourDataResponse>> GetToursAsync();

        Task DeleteTourAsync(int id);
    }
}
