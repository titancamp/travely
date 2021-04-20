using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace Travely.IdentityManager.Service.Abstractions.Models.Response
{
    public class AgencyResponseModel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string LogoFile { get; set; }
        public Status Status { get; set; }

    }
}
