using System;

namespace JPSAGE_ERP.Application.Models.ContractAward
{
    public class PurchaseOrderResponseObject
    {
        public int PoId { get; set; }
        public int SupplierId { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string QuoteRef { get; set; }
        public int? Potype { get; set; }
        public int PodetId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }
        public string PaymentTerms { get; set; }
        public string DeliveryTerms { get; set; }
        public string DeliveryAddress { get; set; }
        public string Title { get; set; }
        public decimal? Vat { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? TotalCost { get; set; }
        public int? NoOfDays { get; set; }
        public string MilestoneDetails { get; set; }
        public int? MilestoneDurationValue { get; set; }
        public int? MilestoneDurationType { get; set; }

    }
}
