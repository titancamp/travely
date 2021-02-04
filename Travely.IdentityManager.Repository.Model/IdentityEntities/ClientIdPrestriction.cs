using System;
using System.Collections.Generic;
using System.Text;

namespace Travely.IdentityManager.Repository.Model.IdentityEntities
{
    public class ClientIdPrestriction
    {
        public int Id { get; set; }
        public string Provider { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
