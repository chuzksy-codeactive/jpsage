using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblHealthSafetyEnvironment
    {
        public int HseId { get; set; }
        public int SupplierId { get; set; }
        public string Hsepolicy { get; set; }
        public string ThirdPartyAudit { get; set; }
        public string HseManagerName { get; set; }
        public string HseManagerEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string Fax { get; set; }
        public string HseCompanyKpi { get; set; }
        public string HseYearN1results { get; set; }
        public string StaffTraining { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
