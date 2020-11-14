using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblEndUserRequisitionProductsMto
    {
        public int Eurpmtoid { get; set; }
        public int? Eurpid { get; set; }
        public int? MtoformId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblEndUserRequisitionProducts Eurp { get; set; }
        public virtual TblMtoforms Mtoform { get; set; }
    }
}
