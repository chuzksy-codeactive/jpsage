using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblAuthList
    {
        public TblAuthList()
        {
            TblAuthApprover = new HashSet<TblAuthApprover>();
            TblAuthChecker = new HashSet<TblAuthChecker>();
        }

        public int AuthId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Status { get; set; }
        public int? StaffId { get; set; }
        public string BatchId { get; set; }
        public string StatusReason { get; set; }
        public int? CheckerStatus { get; set; }
        public string CheckerStatusReason { get; set; }
        public int? ApproverStatus { get; set; }
        public string ApproverStatusReason { get; set; }

        public virtual ICollection<TblAuthApprover> TblAuthApprover { get; set; }
        public virtual ICollection<TblAuthChecker> TblAuthChecker { get; set; }
    }
}
