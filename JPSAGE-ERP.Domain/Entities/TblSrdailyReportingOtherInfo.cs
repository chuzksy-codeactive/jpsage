using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSrdailyReportingOtherInfo
    {
        public int Droiid { get; set; }
        public int? DailyRepId { get; set; }
        public string Challenges { get; set; }
        public string Recommendations { get; set; }
        public string DescriptionofDelay { get; set; }
        public string TimeTaken { get; set; }
        public string Cause { get; set; }
        public string Responsible { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblSrdailyReporting DailyRep { get; set; }
    }
}
