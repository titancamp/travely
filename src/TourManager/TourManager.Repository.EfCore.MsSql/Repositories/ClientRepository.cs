using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Repository.Abstraction;
using TourManager.Repository.EfCore.Context;
using TourManager.Repository.Entities;

namespace TourManager.Repository.EfCore.MsSql.Repositories
{
    /// <summary>
    /// The bookinclient entity's repository
    /// </summary>
    public class ClientRepository : BaseRepository<TourDbContext, TourClientEntity>, IClientRepository
    {
        /// <summary>
        /// Create new instance of client repository
        /// </summary>
        /// <param name="context">The client db context</param>
        public ClientRepository(TourDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Get all clients of a tour
        /// </summary>
        /// <param name="tourId">The tour id</param>
        /// <returns></returns>
        public Task<List<TourClientEntity>> GetAll(int tourId)
        {
            return this.Find(client => client.TourId == tourId);
        }
    }
}