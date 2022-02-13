using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.TourManager.Core.Details;

namespace Travely.TourManager.Core
{
    public interface ITourStatusService
    {
        Task CreateTourStatusAsync(TourStatusRequest model);

        Task<TourStatusResponse> GetTourStatusByIdAsync(int id);

        Task UpdateTourStatusAsync(int id, TourStatusResponse model);

        Task<IEnumerable<TourStatusResponse>> GetTourStatusesAsync();

        Task DeleteTourStatusAsync(int id);
    }
}
