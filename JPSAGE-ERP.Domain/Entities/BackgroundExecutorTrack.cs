using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class BackgroundExecutorTrack
    {
        public long Id { get; set; }
        public string ProcName { get; set; }
        public DateTime RunTime { get; set; }
        public string RunError { get; set; }
    }
}
