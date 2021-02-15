using System;
using System.Collections.Generic;

namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class ApiResource
    {
        private HashSet<ApiResourceClaim> _apiResourceClaims;
        private HashSet<ApiResourceProperty> _apiResourceProperties;
        private HashSet<ApiResourceScope> _apiResourceScopes;
        private HashSet<ApiResourceSecret> _apiResourceSecrets;
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

        public ICollection<ApiResourceClaim> ApiResourceClaims => _apiResourceClaims ??= new HashSet<ApiResourceClaim>();
        public ICollection<ApiResourceProperty> ApiResourceProperties => _apiResourceProperties ??= new HashSet<ApiResourceProperty>();
        public ICollection<ApiResourceScope> ApiResourceScopes => _apiResourceScopes ??= new HashSet<ApiResourceScope>();
        public ICollection<ApiResourceSecret> ApiResourceSecrets => _apiResourceSecrets ??= new HashSet<ApiResourceSecret>();
    }
}
