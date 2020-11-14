using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblQuotationOtherInfoAttachments
    {
        public int Qoiaid { get; set; }
        public int? OtherInfoId { get; set; }
        public int? DocTypeId { get; set; }
        public string DataSheet { get; set; }
        public string Mtocertificate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblDocumentType DocType { get; set; }
        public virtual TblQuotationOtherInfo OtherInfo { get; set; }
    }
}
