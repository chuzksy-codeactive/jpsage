using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblProductServiceCategory
    {
        public TblProductServiceCategory()
        {
            TblCategorySpecialization = new HashSet<TblCategorySpecialization>();
            TblSupplierIdentification = new HashSet<TblSupplierIdentification>();
        }

        public int ProdServId { get; set; }
        public int? CategoryType { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<TblCategorySpecialization> TblCategorySpecialization { get; set; }
        public virtual ICollection<TblSupplierIdentification> TblSupplierIdentification { get; set; }
    }
}
