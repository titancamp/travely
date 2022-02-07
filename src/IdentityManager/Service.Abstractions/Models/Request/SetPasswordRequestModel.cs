namespace Travely.IdentityManager.Service.Abstractions.Models.Request
{
    /// <summary>
    /// Must be deleted after. AgencyId and Email have to be taken from token. 
    /// </summary>
    public class SetPasswordRequestModel
    {
        public int AgencyId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}