using System;
using System.Collections.Generic;
using System.Text;

namespace Travely.IdentityManager.Repository.Model.IdentityEntities
{
    public class Client
    {
        public Client()
        {
            ClientClaims = new HashSet<ClientClaim>();
            ClientCorsOrigins = new HashSet<ClientCorsOrigin>();
            ClientGrantTypes = new HashSet<ClientGrantType>();
            ClientIdPrestrictions = new HashSet<ClientIdPrestriction>();
            ClientPostLogoutRedirectUris = new HashSet<ClientPostLogoutRedirectUri>();
            ClientProperties = new HashSet<ClientProperty>();
            ClientRedirectUris = new HashSet<ClientRedirectUri>();
            ClientScopes = new HashSet<ClientScope>();
            ClientSecrets = new HashSet<ClientSecret>();
        }

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

        public virtual ICollection<ClientClaim> ClientClaims { get; set; }
        public virtual ICollection<ClientCorsOrigin> ClientCorsOrigins { get; set; }
        public virtual ICollection<ClientGrantType> ClientGrantTypes { get; set; }
        public virtual ICollection<ClientIdPrestriction> ClientIdPrestrictions { get; set; }
        public virtual ICollection<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }
        public virtual ICollection<ClientProperty> ClientProperties { get; set; }
        public virtual ICollection<ClientRedirectUri> ClientRedirectUris { get; set; }
        public virtual ICollection<ClientScope> ClientScopes { get; set; }
        public virtual ICollection<ClientSecret> ClientSecrets { get; set; }

    }
}
