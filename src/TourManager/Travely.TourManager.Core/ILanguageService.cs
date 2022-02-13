using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.TourManager.Core.Details;

namespace Travely.TourManager.Core
{
    public interface ILanguageService
    {
        Task CreateLanguageAsync(LanguageRequest model);

        Task<LanguageResponse> GetLanguageByIdAsync(int id);

        Task UpdateLanguageAsync(int id, LanguageResponse model);

        Task<IEnumerable<LanguageResponse>> GetLanguagesAsync();

        Task DeleteLanguageAsync(int id);
    }
}
