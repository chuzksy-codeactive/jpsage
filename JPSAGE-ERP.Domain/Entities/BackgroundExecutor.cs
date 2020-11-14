using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class BackgroundExecutor
    {
        public int Id { get; set; }
        public string BackgroundSp { get; set; }
        public string Description { get; set; }
        public int RunRank { get; set; }
    }
}
