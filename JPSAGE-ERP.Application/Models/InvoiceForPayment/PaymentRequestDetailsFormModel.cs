namespace JPSAGE_ERP.Application.Models.InvoiceForPayment
{
    public class PaymentRequestDetailsFormModel
    {
        public int PayReqMasterId { get; set; }
        public string Description { get; set; }
        public decimal? BudgetEstimate { get; set; }
        public decimal? TechnicalScore { get; set; }
        public string GlaccountCode { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public string AmountInWords { get; set; }
    }
}
