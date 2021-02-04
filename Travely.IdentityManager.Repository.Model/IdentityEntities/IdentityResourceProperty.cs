using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.IdentityManager.Repository.Model.IdentityEntities
{
    public class IdentityResourceProperty
    {
        public int Id { get; set; }
        public int IdentityResourceId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public virtual IdentityResource IdentityResource { get; set; }
    }
}
