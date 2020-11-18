using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Application.Models.SiteReporting
{
    public class DailyReportFormDTO
    {
        public int ProjectId { get; set; }
        public int WFDefId { get; set; }
        public string GeneralSummary { get; set; }
        public string ConstructionActivities { get; set; }
        public string DailyProgress { get; set; }
        public string FollowingDayPlan { get; set; }
        public string ProgressAt { get; set; }
        public decimal ConstructionActual { get; set; }
        public decimal Planned { get; set; }
        public ICollection<HSEReportDTO> HSEReport { get; set; }
        public ICollection<DailyReportingProgressMeasurementDTO> DailyReportingProgressMeasurement { get; set; }
        public ICollection<DailyReportingIssuesDTO> DailyReportingIssues { get; set; }
        public ICollection<DailyReportingDelaysDTO> DailyReportingDelays { get; set; }
        public DailyReportingFileAttachmentsDTO DailyReportingFileAttachments { get; set; }
    }

    public class HSEReportDTO
    {
        public string Title { get; set; }
        public string DetailStatistics { get; set; }
        public string Remarks { get; set; }
    }

    public class DailyReportingProgressMeasurementDTO
    {
        public string Activity { get; set; }
        public decimal CumProgressActual { get; set; }
        public decimal CumPlannedProgress { get; set; }
        public string Remarks { get; set; }
    }

    public class DailyReportingIssuesDTO
    {
        public string Challenges { get; set; }
        public string Recommendations { get; set; }
    }

    public class DailyReportingDelaysDTO
    {
        public string DescriptionOfDelay { get; set; }
        public DateTime TimeTaken { get; set; }
        public string Cause { get; set; }
        public string Responsible { get; set; }
    }

    public class DailyReportingFileAttachmentsDTO
    {
        public IFormFileCollection PermitToWork { get; set; }
        public IFormFileCollection SecurityReport { get; set; }
        public IFormFileCollection ProgressPictures { get; set; }
        public IFormFileCollection Qaqcreport { get; set; }
        public IFormFileCollection LogisticsReport { get; set; }
        public IFormFileCollection SitePersonnelLogReport { get; set; }
        public IFormFileCollection MaterialReport { get; set; }
        public IFormFileCollection Mocreport { get; set; }
    }
}
