namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class ApiResourceClaim
    {
        public int Id { get; set; }
        public int ApiResourceId { get; set; }
        public string Type { get; set; }

        public ApiResource ApiResource { get; set; }
    }
}
