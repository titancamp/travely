using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.TourManager.Repository.Repositories.Entities;

namespace Travely.TourManager.Repository.Repositories
{
    class TourRepository : GenericRepository<Tour>
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
