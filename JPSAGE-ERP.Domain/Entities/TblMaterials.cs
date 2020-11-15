using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblMaterials
    {
        public TblMaterials()
        {
            TblMtoformDetails = new HashSet<TblMtoformDetails>();
        }

        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<TblMtoformDetails> TblMtoformDetails { get; set; }
    }
}
