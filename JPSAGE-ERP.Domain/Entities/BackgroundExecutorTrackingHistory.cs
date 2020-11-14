using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class BackgroundExecutorTrackingHistory
    {
        public long Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string BatchId { get; set; }
        public string ProcName { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public decimal TTime { get; set; }
    }
}
