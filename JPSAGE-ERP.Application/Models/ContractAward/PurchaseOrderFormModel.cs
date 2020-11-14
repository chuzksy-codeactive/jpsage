using System;
using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.ContractAward
{
    public class PurchaseOrderFormModel
    {
        public int SupplierID { get; set; }
        public DateTime IssuedDate { get; set; }
        [MaxLength(100)]
        public string QuoteRef { get; set; }
        public int POType { get; set; }
        public decimal? Poamount { get; set; }
        public int? QuoMasterId { get; set; }
    }
}
