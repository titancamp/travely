using System.Collections.Generic;

namespace Travely.IdentityManager.Repository.Abstractions.Entities
{ 
    public class ApiScope
    {
        private HashSet<ApiScopeClaim> _apiScopeClaim;
        private HashSet<ApiScopeProperty> _apiScopeProperties;
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }

        public virtual ICollection<ApiScopeClaim> ApiScopeClaims => _apiScopeClaim ??= new HashSet<ApiScopeClaim>();
        public virtual ICollection<ApiScopeProperty> ApiScopeProperties => _apiScopeProperties ??= new HashSet<ApiScopeProperty>();
    }
}
