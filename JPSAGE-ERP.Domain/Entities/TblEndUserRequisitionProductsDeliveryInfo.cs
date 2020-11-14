using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblEndUserRequisitionProductsDeliveryInfo
    {
        public int EurpdelInfoId { get; set; }
        public int? Eurpid { get; set; }
        public string DeliveryAddress { get; set; }
        public string SpecialInstructions { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblEndUserRequisitionProducts Eurp { get; set; }
    }
}
