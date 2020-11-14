using JPSAGE_ERP.Application.Interfaces;
using JPSAGE_ERP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPSAGE_ERP.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SiteReportingController : ControllerBase
    {
        private readonly IRepository<TblSrdailyReporting> _dailyReportingRepository;
        private readonly IRepository<TblSrdailyReportingOtherInfo> _dailyReportingOtherInfoRepository;
        private readonly IRepository<TblSrfileAttachments> _fileAttachmentsRepository;
        private readonly IRepository<TblSrnonConformanceReports> _conformanceReportsRepository;

        public SiteReportingController(
                IRepository<TblSrdailyReporting> dailyReportingRepository,
                IRepository<TblSrdailyReportingOtherInfo> dailyReportingOtherInfoRepository,
                IRepository<TblSrfileAttachments> fileAttachmentsRepository,
                IRepository<TblSrnonConformanceReports> conformanceReportsRepository
            )
        {
            this._dailyReportingRepository = dailyReportingRepository;
            this._dailyReportingOtherInfoRepository = dailyReportingOtherInfoRepository;
            this._fileAttachmentsRepository = fileAttachmentsRepository;
            this._conformanceReportsRepository = conformanceReportsRepository;
        }
    }
}
