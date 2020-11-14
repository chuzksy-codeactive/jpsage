using System;

namespace JPSAGE_ERP.Application.Models.InvoiceForPayment
{
    public class InvoiceForPaymentResponseObject
    {

        public int PayRequestMasterID { get; set; }
        public int PaymentBankID { get; set; }
       
        public string Payee { get; set; }
       
        public string AccountNumber { get; set; }
        public int DepartmentID { get; set; }
        public DateTime PayReqDate { get; set; }
        public string PONumber { get; set; }
        public string Description { get; set; }
        public string GLAccountCode { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public string AmountInWords { get; set; }
    }
}
