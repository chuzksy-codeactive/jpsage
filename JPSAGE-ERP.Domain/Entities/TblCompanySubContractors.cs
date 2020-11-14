using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblCompanySubContractors
    {
        public int ComSubConId { get; set; }
        public int? CompanyId { get; set; }
        public string SubContractorName { get; set; }
        public string SubContractorAddress { get; set; }
        public string Services { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual TblCompanyInfo Company { get; set; }
    }
}
