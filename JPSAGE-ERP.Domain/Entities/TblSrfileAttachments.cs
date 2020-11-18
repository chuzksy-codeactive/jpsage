using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSrfileAttachments
    {
        public int Srfaid { get; set; }
        public int? Ncrid { get; set; }
        public int? DocTypeId { get; set; }
        public string UploadedFile { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual TblDocumentType DocType { get; set; }
        public virtual TblSrnonConformanceReports Ncr { get; set; }
    }
}
