using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblLog
    {
        public int LogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? LogDate { get; set; }
        public string Comments { get; set; }
    }
}
