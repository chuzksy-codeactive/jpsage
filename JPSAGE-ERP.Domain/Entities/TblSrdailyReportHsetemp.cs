using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSrdailyReportHsetemp
    {
        public int Drhseid { get; set; }
        public int DailyRepId { get; set; }
        public string Title { get; set; }
        public string DetailsStatistics { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblSrdailyReportingTemp DailyRep { get; set; }
    }
}
