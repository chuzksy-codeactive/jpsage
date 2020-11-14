namespace JPSAGE_ERP.Application.Models.InvoiceForPayment
{
    public class InvoiceDetailsFormModel
    {
        public int? InvoiceId { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public string AmountInWords { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
