using System;
using System.Collections.Generic;
using System.Text;

namespace Travely.IdentityManager.Repository.Model.IdentityEntities
{
    public class ApiScopeClaim
    {
        public int Id { get; set; }
        public int ScopeId { get; set; }
        public string Type { get; set; }

        public virtual ApiScope Scope { get; set; }
    }
}
