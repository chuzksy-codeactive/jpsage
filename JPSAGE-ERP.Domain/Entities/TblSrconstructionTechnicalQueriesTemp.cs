using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSrconstructionTechnicalQueriesTemp
    {
        public TblSrconstructionTechnicalQueriesTemp()
        {
            TblSrconstructionTechnicalQueryAttachmentsTemp = new HashSet<TblSrconstructionTechnicalQueryAttachmentsTemp>();
            TblSrconstructionTechnicalQueryRepliesTemp = new HashSet<TblSrconstructionTechnicalQueryRepliesTemp>();
        }

        public int Ctqid { get; set; }
        public string Ctqtitle { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string Ctqnumber { get; set; }
        public int StaffId { get; set; }
        public DateTime QueryDate { get; set; }
        public string Ctqdescription { get; set; }
        public int? Attention { get; set; }
        public DateTime? ReplyRequiredBy { get; set; }
        public string Priority { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblStaffBioData AttentionNavigation { get; set; }
        public virtual TblCity City { get; set; }
        public virtual TblCountry Country { get; set; }
        public virtual TblStaffBioData Staff { get; set; }
        public virtual TblState State { get; set; }
        public virtual ICollection<TblSrconstructionTechnicalQueryAttachmentsTemp> TblSrconstructionTechnicalQueryAttachmentsTemp { get; set; }
        public virtual ICollection<TblSrconstructionTechnicalQueryRepliesTemp> TblSrconstructionTechnicalQueryRepliesTemp { get; set; }
    }
}
