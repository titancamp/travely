using System;
using System.Collections.Generic;

namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class IdentityResource
    {
        public IdentityResource()
        {

        }

        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool NonEditable { get; set; }

        public virtual ICollection<IdentityResourceClaim> IdentityResourceClaims { get; set; }
        public virtual ICollection<IdentityResourceProperty> IdentityResourceProperties { get; set; }
    }
}
