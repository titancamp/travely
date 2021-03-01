using Travely.ServiceManager.Service;

namespace Travely.ServiceManager.UnitTests
{
    public static class Mocks
    {
        public static Activity Activity = new Activity
        {
            Id = 12,
            Name = "name",
            ChangeUser = 1,
            Email = "email",
            Phone = "phone",
            Website = "www",
            Address = "addr",
            ContactName = "contactName",
            Price = new Price
            {
                Currency = "cur",
                Price_ = 12,
            },
            Type = new ActivityType
            {
                ActivityName = "act",
                AgencyId = 3112,
                Id = 11,
            },
        };
    }
}