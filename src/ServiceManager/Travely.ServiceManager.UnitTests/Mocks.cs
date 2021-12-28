using Travely.ServiceManager.Grpc;

namespace Travely.ServiceManager.UnitTests
{
    public static class Mocks
    {
        public static ActivityType ActivityType = new ActivityType
        {
            ActivityName = "act_name",
            AgencyId = 12,
            Id = 345,
        };

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
            Price = 12,
            Type = ActivityType,
        };
    }
}