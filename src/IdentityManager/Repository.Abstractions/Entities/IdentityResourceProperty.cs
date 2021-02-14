namespace Travely.IdentityManager.Repository.Abstractions.Entities
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
