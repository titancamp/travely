using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.TourManager.Core;
using Travely.TourManager.Core.Details;
using Travely.TourManager.DAL;

namespace Travely.TourManager.BLL
{
    public class LanguageService : ILanguageService
    {
        private readonly DataContext _dbContext;
        public LanguageService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateLanguageAsync(LanguageRequest model)
        {
            if (string.IsNullOrEmpty(model.LanguageName))
                throw new InvalidOperationException("The LanguageName is a required field");

            var data = new Language
            {
                LanguageName = model.LanguageName,
            };
            _dbContext.Languages.Add(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<LanguageResponse> GetLanguageByIdAsync(int id)
        {
            var data = await _dbContext.Languages.Where(v => v.Id == id).Select(s => new LanguageResponse
            {
                LanguageId = s.Id,
                LanguageName = s.LanguageName
            }).FirstOrDefaultAsync();
            if (data == null)
                throw new InvalidOperationException("Language not found");
            return data;
        }

        public async Task UpdateLanguageAsync(int id, LanguageResponse model)
        {
            var data = await _dbContext.Languages.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (data == null)
                throw new InvalidOperationException("Language not found");

            if (string.IsNullOrEmpty(model.LanguageName))
                throw new InvalidOperationException("The LanguageName is a required field");

            bool dataUpdated = false;

            if (data.LanguageName != model.LanguageName)
            {
                dataUpdated = true;
                data.LanguageName = model.LanguageName;
            }

            if (dataUpdated)
                await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageResponse>> GetLanguagesAsync()
        {
            IQueryable<Language> data = _dbContext.Languages;

            return await data.Select(s => new LanguageResponse
            {
                LanguageId = s.Id,
                LanguageName = s.LanguageName
            }).ToListAsync();
        }

        public async Task DeleteLanguageAsync(int id)
        {
            var data = await _dbContext.Languages.Where(n => n.Id == id).FirstOrDefaultAsync();
            if (data == null)
                throw new InvalidOperationException("Language not found");
            _dbContext.Languages.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
