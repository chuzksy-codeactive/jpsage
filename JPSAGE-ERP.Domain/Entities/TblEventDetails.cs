using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblEventDetails
    {
        public int EventDetId { get; set; }
        public int? EventId { get; set; }
        public string Rfxnumber { get; set; }
        public int? Rfxowner { get; set; }
        public string SmartNumber { get; set; }
        public string Rfxstatus { get; set; }
        public DateTime? RfxstartDate { get; set; }
        public DateTime? SubmissionDeadline { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblEvents Event { get; set; }
        public virtual TblStaffBioData RfxownerNavigation { get; set; }
    }
}
