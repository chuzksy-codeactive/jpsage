using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblPaymentRequestMaster
    {
        public TblPaymentRequestMaster()
        {
            TblPaymentRequestDetails = new HashSet<TblPaymentRequestDetails>();
        }

        public int PayReqMasterId { get; set; }
        public int PaymentBankId { get; set; }
        public string Payee { get; set; }
        public string AccountNumber { get; set; }
        public int DepartmentProject { get; set; }
        public DateTime PayReqDate { get; set; }
        public string PayReqNumber { get; set; }
        public int? PoId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblDepartments DepartmentProjectNavigation { get; set; }
        public virtual TblPaymentBank PaymentBank { get; set; }
        public virtual TblPurchaseOrder Po { get; set; }
        public virtual ICollection<TblPaymentRequestDetails> TblPaymentRequestDetails { get; set; }
    }
}
