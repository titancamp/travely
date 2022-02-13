using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.TourManager.Core.Details;

namespace Travely.TourManager.Core
{
    public interface IGenderService
    {
        Task CreateGenderAsync(GenderRequest model);

        Task<GenderResponse> GetGenderByIdAsync(int id);

        Task UpdateGenderAsync(int id, GenderResponse model);

        Task<IEnumerable<GenderResponse>> GetGendersAsync();

        Task DeleteGenderAsync(int id);
    }
}
