using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblQualityManagement
    {
        public int QualMgtId { get; set; }
        public int SupplierId { get; set; }
        public string QualityPolicy { get; set; }
        public string ProductQualMgt { get; set; }
        public string QualityMgt { get; set; }
        public string QualManagerName { get; set; }
        public string QualManagerEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string Fax { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
