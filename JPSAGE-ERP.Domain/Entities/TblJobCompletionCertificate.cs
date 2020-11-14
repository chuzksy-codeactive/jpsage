using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblJobCompletionCertificate
    {
        public int Jccid { get; set; }
        public string CertificateNumber { get; set; }
        public string WorkOrder { get; set; }
        public int? SupplierId { get; set; }
        public string Address { get; set; }
        public string DeliveryAddress { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime? RecieptDate { get; set; }
        public string ServiceDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CompanyId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblCompanyInfo Company { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
