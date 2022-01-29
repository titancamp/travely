using System;

namespace Travely.IdentityClient.Authorization.Entities
{
    [Flags]
    public enum Permission
    {
        TourTemplatesView = 0x00000001,
        TourTemplatesEdit = 0x00000002,
        TourPackagesView = 0x00000004,
        TourPackagesEdit = 0x00000008,
        ReceivableFinancialInfoView = 0x00000010,
        ReceivableFinancialInfoEdit = 0x00000020,
        PayableFinancialInfoView = 0x00000040,
        PayableFinancialInfoEdit = 0x00000080
    }
}
