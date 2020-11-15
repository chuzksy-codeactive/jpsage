using System.ComponentModel;

namespace JPSAGE_ERP.Application.Enums
{
    public enum EDailySiteReport
    {
        [Description("PermitToWork")]
        PermitToWork,

        [Description("SecurityReport")]
        SecurityReport,

        [Description("ProgressPictures")]
        ProgressPictures,

        [Description("QAQCReport")]
        QAQCReport,

        [Description("LogisticReport")]
        LogisticReport,

        [Description("SitePersonnelLogReport")]
        SitePersonnelLogReport,

        [Description("MaterialReport")]
        MaterialReprot,

        [Description("MOCReport")]
        MOCReport,
    }
}
