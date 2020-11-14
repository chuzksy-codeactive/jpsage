using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblActivityLog
    {
        public long ActivityLogId { get; set; }
        public string ProcessName { get; set; }
        public string Description { get; set; }
        public string InitiatedBy { get; set; }
        public string CheckedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
