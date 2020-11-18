using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSrconstructionTechnicalQueryReplies
    {
        public int ReplyId { get; set; }
        public int Ctqid { get; set; }
        public string InitiatorReply { get; set; }
        public DateTime? InitiatorReplyDate { get; set; }
        public string CheckerReply { get; set; }
        public DateTime? CheckerReplyDate { get; set; }
        public string AuthoriserReply { get; set; }
        public DateTime? AuthoriserReplyDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? CheckerId { get; set; }
        public int? AuthoriserId { get; set; }
        public DateTime? QueryCloseDate { get; set; }

        public virtual TblStaffBioData Authoriser { get; set; }
        public virtual TblStaffBioData Checker { get; set; }
        public virtual TblSrconstructionTechnicalQueries Ctq { get; set; }
    }
}
