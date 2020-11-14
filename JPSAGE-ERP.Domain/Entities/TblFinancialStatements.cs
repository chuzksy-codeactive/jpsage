using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblFinancialStatements
    {
        public int FinStatId { get; set; }
        public int SupplierId { get; set; }
        public string FinancialStatement { get; set; }
        public string AnnualReport { get; set; }
        public string FinancialStatementYear2 { get; set; }
        public string FinancialStatementYear3 { get; set; }
        public string TaxIdentificationNo { get; set; }
        public string AuditorName { get; set; }
        public string AuditorAddress { get; set; }
        public string ContactNumber { get; set; }
        public string IsListed { get; set; }
        public string StockMarketInfo { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
