using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblPaymentBank
    {
        public TblPaymentBank()
        {
            TblPaymentRequestMaster = new HashSet<TblPaymentRequestMaster>();
        }

        public int PymntBankId { get; set; }
        public string PaymentBankCode { get; set; }
        public string PaymentBankName { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<TblPaymentRequestMaster> TblPaymentRequestMaster { get; set; }
    }
}
