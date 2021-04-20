namespace Travely.IdentityManager.Service.Abstractions.Models.Request
{
    public class AgencyRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        public string Address { get; set; }
        public string LogoFile { get; set; }
        public string PhoneNumber { get; set; }

    }
}
