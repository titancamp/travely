using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TourManager.Repository.EfCore.Context;
using TourManager.Repository.EfCore.Entities;

namespace TourManager.Repository.EfCore.MsSql
{
    internal class TourRepository : GenericRepository<Tour>
    {
        private TourContext _context;

        public TourRepository(TourContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tour>> GetAllFromTodayAsync()
        {
            return await _context.Tours
                .Where(a => a.StartDate > DateTime.Now)
                .ToListAsync();
        }
    }
}