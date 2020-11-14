using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblCertifyingOrg
    {
        public TblCertifyingOrg()
        {
            TblHseCertification = new HashSet<TblHseCertification>();
            TblQualityCertification = new HashSet<TblQualityCertification>();
        }

        public int CertOrgId { get; set; }
        public string CertOrgName { get; set; }

        public virtual ICollection<TblHseCertification> TblHseCertification { get; set; }
        public virtual ICollection<TblQualityCertification> TblQualityCertification { get; set; }
    }
}
