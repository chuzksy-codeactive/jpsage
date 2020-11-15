using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSrconstructionTechnicalQueryAttachments
    {
        public int QueryAttId { get; set; }
        public int Ctqid { get; set; }
        public string ReferenceNumber { get; set; }
        public string DrawingFile { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblSrconstructionTechnicalQueries Ctq { get; set; }
    }
}
