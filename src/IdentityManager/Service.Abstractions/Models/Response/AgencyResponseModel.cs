namespace Travely.IdentityManager.Service.Abstractions.Models.Response
{
    public class AgencyResponseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int OwnerId { get; set; }
        public string? LogoFile { get; set; }
    }
}
