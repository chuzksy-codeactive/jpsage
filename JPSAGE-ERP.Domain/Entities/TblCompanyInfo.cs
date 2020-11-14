using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblCompanyInfo
    {
        public TblCompanyInfo()
        {
            TblClients = new HashSet<TblClients>();
            TblCompanySubContractors = new HashSet<TblCompanySubContractors>();
            TblDepartments = new HashSet<TblDepartments>();
            TblInvoice = new HashSet<TblInvoice>();
            TblJobCompletionCertificate = new HashSet<TblJobCompletionCertificate>();
            TblMtoforms = new HashSet<TblMtoforms>();
            TblPurchaseOrder = new HashSet<TblPurchaseOrder>();
            TblStaffBioData = new HashSet<TblStaffBioData>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string EmailAddress { get; set; }
        public string WebsiteUrl { get; set; }
        public byte[] CompanyLogo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CompanyCode { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TblClients> TblClients { get; set; }
        public virtual ICollection<TblCompanySubContractors> TblCompanySubContractors { get; set; }
        public virtual ICollection<TblDepartments> TblDepartments { get; set; }
        public virtual ICollection<TblInvoice> TblInvoice { get; set; }
        public virtual ICollection<TblJobCompletionCertificate> TblJobCompletionCertificate { get; set; }
        public virtual ICollection<TblMtoforms> TblMtoforms { get; set; }
        public virtual ICollection<TblPurchaseOrder> TblPurchaseOrder { get; set; }
        public virtual ICollection<TblStaffBioData> TblStaffBioData { get; set; }
    }
}
