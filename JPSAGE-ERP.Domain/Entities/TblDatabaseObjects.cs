using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblDatabaseObjects
    {
        public int DbobjId { get; set; }
        public int? ObjectType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Parameters { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
