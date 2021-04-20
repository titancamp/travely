using System;
using System.Collections.Generic;

namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class Client
    {
        private HashSet<ClientClaim> _clientClaims;
        private HashSet<ClientCorsOrigin> _clientCorsOrigins;
        private HashSet<ClientGrantType> _clientGrantType;
        private HashSet<ClientIdPrestriction> _clientIdPrestrictions;
        private HashSet<ClientPostLogoutRedirectUri> _clientPostLogoutRedirectUris;
        private HashSet<ClientProperty> _clientProperties;
        private HashSet<ClientRedirectUri> _clientRedirectUris;
        private HashSet<ClientScope> _clientScopes;
        private HashSet<ClientSecret> _clientSecrets;

        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string ClientId { get; set; }
        public string ProtocolType { get; set; }
        public bool RequireClientSecret { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public string ClientUri { get; set; }
        public string LogoUri { get; set; }
        public bool RequireConsent { get; set; }
        public bool AllowRememberConsent { get; set; }
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }
        public bool RequirePkce { get; set; }
        public bool AllowPlainTextPkce { get; set; }
        public bool RequireRequestObject { get; set; }
        public bool AllowAccessTokensViaBrowser { get; set; }
        public string FrontChannelLogoutUri { get; set; }
        public bool FrontChannelLogoutSessionRequired { get; set; }
        public string BackChannelLogoutUri { get; set; }
        public bool BackChannelLogoutSessionRequired { get; set; }
        public bool AllowOfflineAccess { get; set; }
        public int IdentityTokenLifetime { get; set; }
        public string AllowedIdentityTokenSigningAlgorithms { get; set; }
        public int AccessTokenLifetime { get; set; }
        public int AuthorizationCodeLifetime { get; set; }
        public int? ConsentLifetime { get; set; }
        public int AbsoluteRefreshTokenLifetime { get; set; }
        public int SlidingRefreshTokenLifetime { get; set; }
        public int RefreshTokenUsage { get; set; }
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public int AccessTokenType { get; set; }
        public bool EnableLocalLogin { get; set; }
        public bool IncludeJwtId { get; set; }
        public bool AlwaysSendClientClaims { get; set; }
        public string ClientClaimsPrefix { get; set; }
        public string PairWiseSubjectSalt { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
        public int? UserSsoLifetime { get; set; }
        public string UserCodeType { get; set; }
        public int DeviceCodeLifetime { get; set; }
        public bool NonEditable { get; set; }

        public virtual ICollection<ClientClaim> ClientClaims => _clientClaims ??= new HashSet<ClientClaim>();
        public virtual ICollection<ClientCorsOrigin> ClientCorsOrigins => _clientCorsOrigins ??= new HashSet<ClientCorsOrigin>();
        public virtual ICollection<ClientGrantType> ClientGrantTypes => _clientGrantType ??= new HashSet<ClientGrantType>();
        public virtual ICollection<ClientIdPrestriction> ClientIdPrestrictions => _clientIdPrestrictions ??= new HashSet<ClientIdPrestriction>();
        public virtual ICollection<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris => _clientPostLogoutRedirectUris ??= new HashSet<ClientPostLogoutRedirectUri>();
        public virtual ICollection<ClientProperty> ClientProperties => _clientProperties ??= new HashSet<ClientProperty>();
        public virtual ICollection<ClientRedirectUri> ClientRedirectUris => _clientRedirectUris ??= new HashSet<ClientRedirectUri>();
        public virtual ICollection<ClientScope> ClientScopes => _clientScopes ??= new HashSet<ClientScope>();
        public virtual ICollection<ClientSecret> ClientSecrets => _clientSecrets ??= new HashSet<ClientSecret>();

    }
}
