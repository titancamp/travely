using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.Repository.Common.Entity.Client;

namespace Travely.ClientManager.Repository.SqlServer.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(ClientDbContext dbContext) : base(dbContext)
        {
        }
    }
}
