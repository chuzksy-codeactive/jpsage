using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSrconstructionTechnicalQueryRepliesTemp
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

        public virtual TblSrconstructionTechnicalQueriesTemp Ctq { get; set; }
    }
}
