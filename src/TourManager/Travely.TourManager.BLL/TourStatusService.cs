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
    public class TourStatusService : ITourStatusService
    {
        private readonly DataContext _dbContext;
        public TourStatusService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTourStatusAsync(TourStatusRequest model)
        {
            if (string.IsNullOrEmpty(model.TourStatusName))
                throw new InvalidOperationException("The TourStatusName is a required field");

            var data = new TourStatus
            {
                StatusName = model.TourStatusName
            };
            _dbContext.TourStatuses.Add(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TourStatusResponse> GetTourStatusByIdAsync(int id)
        {
            var data = await _dbContext.TourStatuses.Where(v => v.Id == id).Select(s => new TourStatusResponse
            {
                TourStatusId = s.Id,
                TourStatusName = s.StatusName
            }).FirstOrDefaultAsync();
            if (data == null)
                throw new InvalidOperationException("Status not found");
            return data;
        }

        public async Task UpdateTourStatusAsync(int id, TourStatusResponse model)
        {
            var data = await _dbContext.TourStatuses.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (data == null)
                throw new InvalidOperationException("Status not found");

            if (string.IsNullOrEmpty(model.TourStatusName))
                throw new InvalidOperationException("The TourStatusName is a required field");

            bool dataUpdated = false;

            if (data.StatusName != model.TourStatusName)
            {
                dataUpdated = true;
                data.StatusName = model.TourStatusName;
            }

            if (dataUpdated)
                await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TourStatusResponse>> GetTourStatusesAsync()
        {
            IQueryable<TourStatus> data = _dbContext.TourStatuses;

            return await data.Select(s => new TourStatusResponse
            {
                TourStatusId = s.Id,
                TourStatusName = s.StatusName
            }).ToListAsync();
        }

        public async Task DeleteTourStatusAsync(int id)
        {
            var data = await _dbContext.TourStatuses.Where(n => n.Id == id).FirstOrDefaultAsync();
            if (data == null)
                throw new InvalidOperationException("Status not found");
            _dbContext.TourStatuses.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
