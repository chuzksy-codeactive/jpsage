using System;
using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.JustificationOfAward
{
    public class JustificationOfAwardFormModel
    {
        public int? ProjectId { get; set; }
        [MaxLength(200)]
        public string Rqnnumber { get; set; }
        public int? Rfqid { get; set; }
        public int? SupplierId { get; set; }
        public decimal? ScoreTechnicalEval { get; set; }
        public decimal? VendorBidPrice { get; set; }
        public decimal? ScoreCommercialEval { get; set; }
        [MaxLength(100)]
        public string EndUser { get; set; }
        public int? EndUserDepartmentId { get; set; }
        public DateTime? Date { get; set; }
        public string JustificationofAward { get; set; }
    }
}
