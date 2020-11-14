using JPSAGE_ERP.Application.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.InvoiceForPayment
{
    public class PaymentRequestFormModel
    {
        public int PaymentBankID { get; set; }
        [MaxLength(200)]
        public string Payee { get; set; }
        [MaxLength(20)]
        public string AccountNumber { get; set; }
        public int DepartmentID { get; set; }
        [DateTimeAttribute]
        public DateTime PayReqDate { get; set; }
        public string PONumber { get; set; }
        public string Description { get; set; }
        [MaxLength(50)]
        public string GLAccountCode { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        [MaxLength(100)]
        public string AmountInWords { get; set; }

    }
}
