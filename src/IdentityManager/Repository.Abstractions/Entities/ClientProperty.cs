namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class ClientProperty
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public virtual Client Client { get; set; }
    }
}
