using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblMtoformDetails
    {
        public int MtoformDetId { get; set; }
        public int MtoformId { get; set; }
        public string DocumentNumber { get; set; }
        public string Item { get; set; }
        public string Size { get; set; }
        public string Schedule { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
        public int? ActualQtyRequired { get; set; }
        public decimal? Spare { get; set; }
        public int? TotalRequired { get; set; }
        public int? Unit { get; set; }
        public string Rfq { get; set; }
        public int? QuantityRequired { get; set; }
        public int? QuantitytoBuy { get; set; }
        public int? Voltage { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string Remarks { get; set; }
        public int? UnitToOrder { get; set; }
        public int? ManufacturerId { get; set; }
        public string ModelNumber { get; set; }
        public string AdditionalInfo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? MaterialId { get; set; }
        public decimal? Amount { get; set; }
        public int? Rate { get; set; }

        public virtual TblCity City { get; set; }
        public virtual TblCountry Country { get; set; }
        public virtual TblManufacturers Manufacturer { get; set; }
        public virtual TblMaterials Material { get; set; }
        public virtual TblMtoforms Mtoform { get; set; }
        public virtual TblState State { get; set; }
    }
}
