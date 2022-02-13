using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.TourManager.Core.Details;

namespace Travely.TourManager.Core
{
    public interface ITourTypeService
    {
        Task CreateTourTypeAsync(TourTypeRequest model);

        Task<TourTypeResponse> GetTourTypeByIdAsync(int id);

        Task UpdateTourTypeAsync(int id, TourTypeResponse model);

        Task<IEnumerable<TourTypeResponse>> GetTourTypesAsync();

        Task DeleteTourTypeAsync(int id);
    }
}
