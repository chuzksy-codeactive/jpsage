using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblServices
    {
        public TblServices()
        {
            TblSubContractedServices = new HashSet<TblSubContractedServices>();
        }

        public int ServiceId { get; set; }
        public int? ServCatId { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual TblServicesCategory ServCat { get; set; }
        public virtual ICollection<TblSubContractedServices> TblSubContractedServices { get; set; }
    }
}
