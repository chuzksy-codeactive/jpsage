using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblEventOtherInfo
    {
        public int EventOtherInfoId { get; set; }
        public int? EventId { get; set; }
        public string Notes { get; set; }
        public string Attachments { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblEvents Event { get; set; }
    }
}
