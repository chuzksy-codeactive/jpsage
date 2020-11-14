using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblEndUserRequisitionProductsOtherInfo
    {
        public int EurpotherInfoId { get; set; }
        public int? Eurpid { get; set; }
        public bool? SparesRequired { get; set; }
        public string AsservicesRq { get; set; }
        public string DataSheet { get; set; }
        public string Mto { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblEndUserRequisitionProducts Eurp { get; set; }
    }
}
