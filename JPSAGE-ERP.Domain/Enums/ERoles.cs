using System.ComponentModel;

namespace JPSAGE_ERP.Domain.Enums
{
    public enum ERoles
    {
        [Description("Admin")]
        ADMIN = 1,

        [Description("Checker")]
        CHECKER = 2,

        [Description("Authorizer")]
        AUTHORIZER = 3,

        [Description("Staff")]
        STAFF = 4,

        [Description("VendorAdmin")]
        VENDORADMIN = 5,

        [Description("Vendor")] 
        VENDOR = 6
    }
}
