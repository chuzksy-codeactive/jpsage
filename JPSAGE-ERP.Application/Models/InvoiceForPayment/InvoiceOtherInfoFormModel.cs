namespace JPSAGE_ERP.Application.Models.InvoiceForPayment
{
    public class InvoiceOtherInfoFormModel
    {
        public int? InvoiceId { get; set; }
        public int? PaymentBankId { get; set; }
        public string AccountDetails { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string SortCode { get; set; }
    }
}
