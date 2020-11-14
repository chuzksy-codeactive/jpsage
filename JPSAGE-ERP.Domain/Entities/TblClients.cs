using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblClients
    {
        public TblClients()
        {
            TblEndUserRequisitionProducts = new HashSet<TblEndUserRequisitionProducts>();
            TblEndUserRequisitionServices = new HashSet<TblEndUserRequisitionServices>();
            TblInvoice = new HashSet<TblInvoice>();
            TblMtoforms = new HashSet<TblMtoforms>();
            TblQuotationMaster = new HashSet<TblQuotationMaster>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public byte[] ClientLogo { get; set; }
        public string Address { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string EmailAddress { get; set; }
        public string WebSiteUrl { get; set; }
        public int? CompanyId { get; set; }
        public string ClientCode { get; set; }

        public virtual TblCompanyInfo Company { get; set; }
        public virtual ICollection<TblEndUserRequisitionProducts> TblEndUserRequisitionProducts { get; set; }
        public virtual ICollection<TblEndUserRequisitionServices> TblEndUserRequisitionServices { get; set; }
        public virtual ICollection<TblInvoice> TblInvoice { get; set; }
        public virtual ICollection<TblMtoforms> TblMtoforms { get; set; }
        public virtual ICollection<TblQuotationMaster> TblQuotationMaster { get; set; }
    }
}
