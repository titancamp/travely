namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class ClientCorsOrigin
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
