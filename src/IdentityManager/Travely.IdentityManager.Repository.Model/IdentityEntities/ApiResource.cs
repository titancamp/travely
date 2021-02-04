using System;
using System.Collections.Generic;
using System.Text;

namespace Travely.IdentityManager.Repository.Model.IdentityEntities
{
    public class ApiResource
    {
        public ApiResource()
        {
            ApiResourceClaims = new HashSet<ApiResourceClaim>();
            ApiResourceProperties = new HashSet<ApiResourceProperty>();
            ApiResourceScopes = new HashSet<ApiResourceScope>();
            ApiResourceSecrets = new HashSet<ApiResourceSecret>();
        }

        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string AllowedAccessTokenSigningAlgorithms { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
        public bool NonEditable { get; set; }

        public virtual ICollection<ApiResourceClaim> ApiResourceClaims { get; set; }
        public virtual ICollection<ApiResourceProperty> ApiResourceProperties { get; set; }
        public virtual ICollection<ApiResourceScope> ApiResourceScopes { get; set; }
        public virtual ICollection<ApiResourceSecret> ApiResourceSecrets { get; set; }
    }
}
