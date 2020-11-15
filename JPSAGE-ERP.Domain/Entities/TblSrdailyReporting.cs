using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSrdailyReporting
    {
        public TblSrdailyReporting()
        {
            TblSrdailyReportFileAttachments = new HashSet<TblSrdailyReportFileAttachments>();
            TblSrdailyReportHse = new HashSet<TblSrdailyReportHse>();
            TblSrdailyReportProgressMeasurement = new HashSet<TblSrdailyReportProgressMeasurement>();
            TblSrdailyReportingDelays = new HashSet<TblSrdailyReportingDelays>();
            TblSrdailyReportingIssues = new HashSet<TblSrdailyReportingIssues>();
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
        public virtual ICollection<TblSrdailyReportFileAttachments> TblSrdailyReportFileAttachments { get; set; }
        public virtual ICollection<TblSrdailyReportHse> TblSrdailyReportHse { get; set; }
        public virtual ICollection<TblSrdailyReportProgressMeasurement> TblSrdailyReportProgressMeasurement { get; set; }
        public virtual ICollection<TblSrdailyReportingDelays> TblSrdailyReportingDelays { get; set; }
        public virtual ICollection<TblSrdailyReportingIssues> TblSrdailyReportingIssues { get; set; }
    }
}
