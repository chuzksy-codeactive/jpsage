using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSrdailyReportProgressMeasurementTemp
    {
        public int ProMeId { get; set; }
        public int DailyRepId { get; set; }
        public string Activity { get; set; }
        public decimal CumProgressActual { get; set; }
        public decimal CumPlannedProgress { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblSrdailyReportingTemp DailyRep { get; set; }
    }
}
