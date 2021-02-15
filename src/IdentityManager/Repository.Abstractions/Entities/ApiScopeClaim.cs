namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class ApiScopeClaim
    {
        public int Id { get; set; }
        public int ScopeId { get; set; }
        public string Type { get; set; }

        public ApiScope Scope { get; set; }
    }
}
