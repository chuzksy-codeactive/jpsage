using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSrdailyReporting
    {
        public TblSrdailyReporting()
        {
            TblSrdailyReportingOtherInfo = new HashSet<TblSrdailyReportingOtherInfo>();
            TblSrfileAttachments = new HashSet<TblSrfileAttachments>();
        }

        public int DailyRepId { get; set; }
        public string Activity { get; set; }
        public decimal? CumProgressActual { get; set; }
        public decimal? CumPlannedProgress { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<TblSrdailyReportingOtherInfo> TblSrdailyReportingOtherInfo { get; set; }
        public virtual ICollection<TblSrfileAttachments> TblSrfileAttachments { get; set; }
    }
}
