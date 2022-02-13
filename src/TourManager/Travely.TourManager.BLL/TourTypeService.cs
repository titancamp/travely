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
    public class TourTypeService : ITourTypeService
    {
        private readonly DataContext _dbContext;
        public TourTypeService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTourTypeAsync(TourTypeRequest model)
        {
            if (string.IsNullOrEmpty(model.TourTypeName))
                throw new InvalidOperationException("The TourTypeName is a required field");

            var data = new TourType
            {
                TypeName = model.TourTypeName,
            };
            _dbContext.TourTypes.Add(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TourTypeResponse> GetTourTypeByIdAsync(int id)
        {
            var data = await _dbContext.TourTypes.Where(v => v.Id == id).Select(s => new TourTypeResponse
            {
                TourTypeId = s.Id,
                TourTypeName = s.TypeName
            }).FirstOrDefaultAsync();
            if (data == null)
                throw new InvalidOperationException("Tour type not found");
            return data;
        }

        public async Task UpdateTourTypeAsync(int id, TourTypeResponse model)
        {
            var data = await _dbContext.TourTypes.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (data == null)
                throw new InvalidOperationException("Tour type not found");

            if (string.IsNullOrEmpty(model.TourTypeName))
                throw new InvalidOperationException("The TourTypeName is a required field");

            bool dataUpdated = false;

            if (data.TypeName != model.TourTypeName)
            {
                dataUpdated = true;
                data.TypeName = model.TourTypeName;
            }

            if (dataUpdated)
                await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TourTypeResponse>> GetTourTypesAsync()
        {
            IQueryable<TourType> data = _dbContext.TourTypes;

            return await data.Select(s => new TourTypeResponse
            {
                TourTypeId = s.Id,
                TourTypeName = s.TypeName
            }).ToListAsync();
        }

        public async Task DeleteTourTypeAsync(int id)
        {
            var data = await _dbContext.TourTypes.Where(n => n.Id == id).FirstOrDefaultAsync();
            if (data == null)
                throw new InvalidOperationException("Tour type not found");
            _dbContext.TourTypes.Remove(data);
            await _dbContext.SaveChangesAsync();
        }

    }
}
