using System;
using System.Collections.Generic;
using System.Text;
using Travely.ClientManager.Abstraction.Abstraction.Repository;
using Travely.ClientManager.Abstraction.Entity;

namespace Travely.ClientManager.Repository.Repository
{
    public class TouristRepository : BaseRepository<Tourist>, ITouristRepository
    {
        public TouristRepository(TouristContext dbContext) : base(dbContext)
        {
        }
    }
}
