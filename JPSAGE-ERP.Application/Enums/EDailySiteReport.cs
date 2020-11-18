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

        [Description("Qaqcreport")]
        QAQCReport,

        [Description("LogisticsReport")]
        LogisticReport,

        [Description("SitePersonnelLogReport")]
        SitePersonnelLogReport,

        [Description("MaterialReport")]
        MaterialReprot,

        [Description("Mocreport")]
        MOCReport,
    }
}
