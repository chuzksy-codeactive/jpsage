using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblEvents
    {
        public TblEvents()
        {
            TblEventDetails = new HashSet<TblEventDetails>();
            TblEventOtherInfo = new HashSet<TblEventOtherInfo>();
            TblQuotationMaster = new HashSet<TblQuotationMaster>();
        }

        public int EventId { get; set; }
        public string EventNumber { get; set; }
        public string EventDescription { get; set; }
        public int? EventType { get; set; }
        public int? EventStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ResponseNumber { get; set; }
        public int? ResponseStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<TblEventDetails> TblEventDetails { get; set; }
        public virtual ICollection<TblEventOtherInfo> TblEventOtherInfo { get; set; }
        public virtual ICollection<TblQuotationMaster> TblQuotationMaster { get; set; }
    }
}
