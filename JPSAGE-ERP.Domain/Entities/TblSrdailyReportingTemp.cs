using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSrdailyReportingTemp
    {
        public TblSrdailyReportingTemp()
        {
            TblSrdailyReportFileAttachmentsTemp = new HashSet<TblSrdailyReportFileAttachmentsTemp>();
            TblSrdailyReportHsetemp = new HashSet<TblSrdailyReportHsetemp>();
            TblSrdailyReportProgressMeasurementTemp = new HashSet<TblSrdailyReportProgressMeasurementTemp>();
            TblSrdailyReportingDelaysTemp = new HashSet<TblSrdailyReportingDelaysTemp>();
            TblSrdailyReportingIssuesTemp = new HashSet<TblSrdailyReportingIssuesTemp>();
        }

        public int DailyRepId { get; set; }
        public int ProjectId { get; set; }
        public string GeneralSummary { get; set; }
        public string ConstructionActivities { get; set; }
        public string DailyProgress { get; set; }
        public string FollowingDayPlan { get; set; }
        public string ProgressAt { get; set; }
        public decimal ConstructionActual { get; set; }
        public decimal Planned { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblProjects Project { get; set; }
        public virtual ICollection<TblSrdailyReportFileAttachmentsTemp> TblSrdailyReportFileAttachmentsTemp { get; set; }
        public virtual ICollection<TblSrdailyReportHsetemp> TblSrdailyReportHsetemp { get; set; }
        public virtual ICollection<TblSrdailyReportProgressMeasurementTemp> TblSrdailyReportProgressMeasurementTemp { get; set; }
        public virtual ICollection<TblSrdailyReportingDelaysTemp> TblSrdailyReportingDelaysTemp { get; set; }
        public virtual ICollection<TblSrdailyReportingIssuesTemp> TblSrdailyReportingIssuesTemp { get; set; }
    }
}
