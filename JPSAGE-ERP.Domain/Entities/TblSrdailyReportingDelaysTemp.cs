﻿using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSrdailyReportingDelaysTemp
    {
        public int DelayId { get; set; }
        public int DailyRepId { get; set; }
        public string DescriptionofDelay { get; set; }
        public DateTime TimeTaken { get; set; }
        public string Cause { get; set; }
        public string Responsible { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblSrdailyReportingTemp DailyRep { get; set; }
    }
}
