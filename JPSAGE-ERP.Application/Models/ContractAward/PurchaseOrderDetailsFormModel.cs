using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPSAGE_ERP.Application.Models.ContractAward
{
    public class PurchaseOrderDetailsFormModel
    {
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }
        [MaxLength(500)]
        public string PaymentTerms { get; set; }
        [MaxLength(500)]
        public string DeliveryTerms { get; set; }
        [MaxLength(500)]
        public string DeliveryAddress { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal VAT { get; set; }
        public int CurrencyID { get; set; }
        public decimal SubTotal { get; set; }
        public decimal UniCost { get; set; }
        public decimal TotalCost { get; set; }
        public int NoOfDays { get; set; }

    }
}
