using System;
using System.Collections.Generic;
using System.Text;

namespace Travely.IdentityManager.Repository.Model.IdentityEntities
{
    public partial class ApiScopeProperty
    {
        public int Id { get; set; }
        public int ScopeId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public virtual ApiScope Scope { get; set; }
    }
}
