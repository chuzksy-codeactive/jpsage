using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblPurchaseOrderDetails
    {
        public int PodetId { get; set; }
        public int? PoId { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Total { get; set; }
        public int? PaymentType { get; set; }
        public string DeliveryTerms { get; set; }
        public string DeliveryAddress { get; set; }
        public string Title { get; set; }
        public decimal? Vat { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? TotalCost { get; set; }
        public int? NoOfDays { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblCurrency Currency { get; set; }
        public virtual TblPurchaseOrder Po { get; set; }
    }
}
