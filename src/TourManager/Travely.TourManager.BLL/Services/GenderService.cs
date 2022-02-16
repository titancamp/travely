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
    public class GenderService : IGenderService
    {
        private readonly DataContext _dbContext;
        public GenderService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateGenderAsync(GenderRequest model)
        {
            if (string.IsNullOrEmpty(model.GenderName))
                throw new InvalidOperationException("The GenderName is a required field");

            var data = new Gender
            {
                Sex = model.GenderName,
            };
            _dbContext.Genders.Add(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<GenderResponse> GetGenderByIdAsync(int id)
        {
            var data = await _dbContext.Genders.Where(v => v.Id == id).Select(s => new GenderResponse
            {
                GenderId = s.Id,
                GenderName = s.Sex
            }).FirstOrDefaultAsync();
            if (data == null)
                throw new InvalidOperationException("Gender not found");
            return data;
        }

        public async Task UpdateGenderAsync(int id, GenderResponse model)
        {
            var data = await _dbContext.Genders.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (data == null)
                throw new InvalidOperationException("Gender not found");

            if (string.IsNullOrEmpty(model.GenderName))
                throw new InvalidOperationException("The GenderName is a required field");

            bool dataUpdated = false;

            if (data.Sex != model.GenderName)
            {
                dataUpdated = true;
                data.Sex = model.GenderName;
            }

            if (dataUpdated)
                await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<GenderResponse>> GetGendersAsync()
        {
            IQueryable<Gender> data = _dbContext.Genders;

            return await data.Select(s => new GenderResponse
            {
                GenderId = s.Id,
                GenderName = s.Sex
            }).ToListAsync();
        }

        public async Task DeleteGenderAsync(int id)
        {
            var data = await _dbContext.Genders.Where(n => n.Id == id).FirstOrDefaultAsync();
            if (data == null)
                throw new InvalidOperationException("Gender not found");
            _dbContext.Genders.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
