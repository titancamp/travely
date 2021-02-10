using System;
using System.Collections.Generic;
using System.Text;
using Travely.ClientManager.Repository.Abstraction;
using Travely.ClientManager.Repository.Entity.Client;

namespace Travely.ClientManager.Repository.Repository
{
    public class TuristRepository : BaseRepository<Turist>, ITuristRepository
    {
        public TuristRepository(TuristDbContext dbContext) : base(dbContext)
        {
        }
    }
}
