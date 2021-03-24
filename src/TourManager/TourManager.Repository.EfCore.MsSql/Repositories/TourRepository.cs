using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TourManager.Repository.Abstraction;
using TourManager.Repository.EfCore.Context;
using TourManager.Repository.Entities;
using TourManager.Repository.Models;

namespace TourManager.Repository.EfCore.MsSql.Repositories
{
    /// <summary>
    /// The tour entity's repository
    /// </summary>
    public class TourRepository : BaseRepository<TourEntity>, ITourRepository
    {
        /// <summary>
        /// Create new instance of tour repository
        /// </summary>
        /// <param name="context">The tour db context</param>
        public TourRepository(TourDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Get tours
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <returns></returns>
        public async Task<List<TourEntity>> Get(GetTourFilter filter)
        {
            Expression<Func<TourEntity, bool>> filterExp = x => x.AgencyId == filter.AgencyId;

            if (filter.StartDate != null)
            {
                var compiled = filterExp.Compile();
                filterExp = x => compiled(x) && x.StartDate >= filter.StartDate;
            }

            if (filter.EndDate != null)
            {
                var compiled = filterExp.Compile();
                filterExp = x => compiled(x) && x.EndDate <= filter.EndDate;
            }

            return await this.Find(filterExp);
        }
    }
}