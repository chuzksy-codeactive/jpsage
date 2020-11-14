using System;

namespace JPSAGE_ERP.Application.Models.InvoiceForPayment
{
    public class PaymentRequestMasterFormModel
    {
        public int PaymentBankId { get; set; }
        public string Payee { get; set; }
        public string AccountNumber { get; set; }
        public int DepartmentProject { get; set; }
        public DateTime PayReqDate { get; set; }
        public string PayReqNumber { get; set; }
        public int? PoId { get; set; }
    }
}
