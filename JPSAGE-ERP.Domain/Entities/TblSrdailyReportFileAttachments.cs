using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSrdailyReportFileAttachments
    {
        public int Srdrfaid { get; set; }
        public int DailyRepId { get; set; }
        public string PermitToWork { get; set; }
        public string SecurityReport { get; set; }
        public string ProgressPictures { get; set; }
        public string Qaqcreport { get; set; }
        public string LogisticsReport { get; set; }
        public string SitePersonnelLogReport { get; set; }
        public string MaterialReport { get; set; }
        public string Mocreport { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblSrdailyReporting DailyRep { get; set; }
    }
}
