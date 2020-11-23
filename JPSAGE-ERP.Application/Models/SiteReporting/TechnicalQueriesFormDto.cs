using Microsoft.AspNetCore.Http;
using System;

namespace JPSAGE_ERP.Application.Models.SiteReporting
{
    public class TechnicalQueriesFormDto
    {
        public int ProjectId { get; set; }
        public string CtqTitle { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string CtqNumber { get; set; }
        public DateTime QueryDate { get; set; }
        public string CtqDescription { get; set; }
        public int AttendeeId { get; set; }
        public DateTime ReplyRequiredBy { get; set; }
        public int Priority { get; set; }
        public IFormFile DrawingFile { get; set; }
    }

    public class InitiatorReplyFormDto
    {
        public int CtqId { get; set; }
        public string InitiatorReply { get; set; }
        public int InitiatorAcceptance { get; set; }
        public DateTime InitiatorReplyDate { get; set; }
    }

    public class AttentionReplyFormDto
    {
        public string AttentionReply { get; set; }
        public DateTime AttentionDate { get; set; }
    }
}
