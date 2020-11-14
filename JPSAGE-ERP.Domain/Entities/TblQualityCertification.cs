using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblQualityCertification
    {
        public int QualCertId { get; set; }
        public int SupplierId { get; set; }
        public string Details { get; set; }
        public string NameofCertificate { get; set; }
        public int CertOrgId { get; set; }
        public DateTime? ValidityDate { get; set; }
        public string CertificateCopy { get; set; }

        public virtual TblCertifyingOrg CertOrg { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
