using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TourManager.Repository.Entities;
using TourManager.Repository.EfCore.Context;

namespace TourManager.Repository.EfCore.MsSql.Repositories
{
    public class TourRepository : BaseRepository<Tour>
    {
        public TourRepository(TourDbContext context) : base(context) { }

        public async Task<IEnumerable<Tour>> GetAllFromTodayAsync()
        {
            var query = DbSet.AsNoTracking()
                .Where(a => a.StartDate > DateTime.Now);

            return await query.ToListAsync();
        }
    }
}