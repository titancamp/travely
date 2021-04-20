namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class IdentityResourceClaim
    {
        public int Id { get; set; }
        public int IdentityResourceId { get; set; }
        public string Type { get; set; }

        public IdentityResource IdentityResource { get; set; }
    }
}
