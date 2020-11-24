using AutoMapper;
using Hangfire;
using JPSAGE_ERP.Application.Enums;
using JPSAGE_ERP.Application.Helpers;
using JPSAGE_ERP.Application.Interfaces;
using JPSAGE_ERP.Application.Models.Responses;
using JPSAGE_ERP.Application.Models.SiteReporting;
using JPSAGE_ERP.Application.Services;
using JPSAGE_ERP.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JPSAGE_ERP.WebAPI.Controllers
{
    /// <summary>
    /// Controller for daily site reporting
    /// </summary>
    [Route("api/v1/sitereports")]
    [Authorize]
    [ApiController]
    public class SiteReportingController : ControllerBase
    {
        private readonly IRepository<TblSrdailyReportingTemp> _tblSrdailyReportingTemp;
        private readonly IRepository<TblSrdailyReportHsetemp> _tblSrdailyReportHsetemp;
        private readonly IRepository<TblSrconstructionTechnicalQueriesTemp> _tblSrContructionTechnicalQueries;
        private readonly IRepository<TblSrconstructionTechnicalQueryAttachmentsTemp> _tblSrconstructionTechnicalQueryAttachmentsTemp;
        private readonly IRepository<TblSrconstructionTechnicalQueryRepliesTemp> _tblSrconstructionTechnicalQueryRepliesTemp;
        private readonly IRepository<TblSrdailyReportFileAttachmentsTemp> _tblSrdailyReportFileAttachmentsTemp;
        private readonly IRepository<TblSrdailyReportProgressMeasurementTemp> _tblSrdailyReportProgressMeasurementTemp;
        private readonly IRepository<TblSrdailyReportingIssuesTemp> _tblSrdailyReportingIssuesTemp;
        private readonly IRepository<TblSrdailyReportingDelaysTemp> _tblSrdailyReportingDelaysTemp;
        private readonly IRepository<TblCompanyInfo> _tblCompanyInfo;
        private readonly IRepository<TblCountry> _tblCountry;
        private readonly IRepository<TblState> _tblState;
        private readonly IRepository<TblCity> _tblCity;
        private readonly IRepository<TblProjects> _tblProject;
        private readonly IRepository<TblAuthList> _auditRepository;
        private readonly IRepository<TblStaffBioData> _staffRepository;
        private readonly IRepository<TblCodeGenerator> _codeGeneratorRepository;
        private readonly IRepository<TblWorkflowProcessDef> _tblWorkflowProcessDef;
        private readonly ISiteReportRepository _siteReportRepository;
        private readonly IUploadFileToBlob _uploadFile;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;


        /// <summary>
        /// This constuctor is used for dependency injections
        /// </summary>
        /// <param name="tblSrdailyReportingTemp"></param>
        /// <param name="tblSrdailyReportHsetemp"></param>
        /// <param name="tblSrContructionTechnicalQueries"></param>
        /// <param name="tblSrconstructionTechnicalQueryAttachmentsTemp"></param>
        /// <param name="tblSrconstructionTechnicalQueryRepliesTemp"></param>
        /// <param name="tblSrdailyReportFileAttachmentsTemp"></param>
        /// <param name="tblSrdailyReportProgressMeasurementTemp"></param>
        /// <param name="tblSrdailyReportingIssuesTemp"></param>
        /// <param name="tblSrdailyReportingDelaysTemp"></param>
        /// <param name="tblWorkflowProcessDef"></param>
        /// <param name="codeGeneratorRepository"></param>
        /// <param name="auditRepository"></param>
        /// <param name="staffRepository"></param>
        /// <param name="tblCountry"></param>
        /// <param name="tblState"></param>
        /// <param name="tblCity"></param>
        /// <param name="tblCompanyInfo"></param>
        /// <param name="tblProject"></param>
        /// <param name="uploadFile"></param>
        /// <param name="configuration"></param>
        /// <param name="siteReportRepository"></param>
        /// <param name="emailSender"></param>
        /// <param name="mapper"></param>
        public SiteReportingController(
                IRepository<TblSrdailyReportingTemp> tblSrdailyReportingTemp,
                IRepository<TblSrdailyReportHsetemp> tblSrdailyReportHsetemp,
                IRepository<TblSrconstructionTechnicalQueriesTemp> tblSrContructionTechnicalQueries,
                IRepository<TblSrconstructionTechnicalQueryAttachmentsTemp> tblSrconstructionTechnicalQueryAttachmentsTemp,
                IRepository<TblSrconstructionTechnicalQueryRepliesTemp> tblSrconstructionTechnicalQueryRepliesTemp,
                IRepository<TblSrdailyReportFileAttachmentsTemp> tblSrdailyReportFileAttachmentsTemp,
                IRepository<TblSrdailyReportProgressMeasurementTemp> tblSrdailyReportProgressMeasurementTemp,
                IRepository<TblSrdailyReportingIssuesTemp> tblSrdailyReportingIssuesTemp,
                IRepository<TblSrdailyReportingDelaysTemp> tblSrdailyReportingDelaysTemp,
                IRepository<TblWorkflowProcessDef> tblWorkflowProcessDef,
                IRepository<TblCodeGenerator> codeGeneratorRepository,
                IRepository<TblAuthList> auditRepository,
                IRepository<TblStaffBioData> staffRepository,
                IRepository<TblCountry> tblCountry,
                IRepository<TblState> tblState,
                IRepository<TblCity> tblCity,
                IRepository<TblCompanyInfo> tblCompanyInfo,
                IRepository<TblProjects> tblProject,
                IUploadFileToBlob uploadFile,
                IConfiguration configuration,
                ISiteReportRepository siteReportRepository,
                IEmailSender emailSender,
                IMapper mapper
            )
        {
            _tblSrdailyReportingTemp = tblSrdailyReportingTemp;
            _tblSrdailyReportHsetemp = tblSrdailyReportHsetemp;
            _tblSrContructionTechnicalQueries = tblSrContructionTechnicalQueries;
            _tblSrconstructionTechnicalQueryAttachmentsTemp = tblSrconstructionTechnicalQueryAttachmentsTemp;
            _tblSrconstructionTechnicalQueryRepliesTemp = tblSrconstructionTechnicalQueryRepliesTemp;
            _tblSrdailyReportFileAttachmentsTemp = tblSrdailyReportFileAttachmentsTemp;
            _tblSrdailyReportProgressMeasurementTemp = tblSrdailyReportProgressMeasurementTemp;
            _tblSrdailyReportingIssuesTemp = tblSrdailyReportingIssuesTemp;
            _tblSrdailyReportingDelaysTemp = tblSrdailyReportingDelaysTemp;
            _tblWorkflowProcessDef = tblWorkflowProcessDef;
            _auditRepository = auditRepository;
            _staffRepository = staffRepository;
            _codeGeneratorRepository = codeGeneratorRepository;
            _uploadFile = uploadFile;
            Configuration = configuration;
            _siteReportRepository = siteReportRepository;
            _emailSender = emailSender;
            _tblCountry = tblCountry;
            _tblCompanyInfo = tblCompanyInfo;
            _tblState = tblState;
            _tblCity = tblCity;
            _tblProject = tblProject;
            _mapper = mapper;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method returns the user Id
        /// </summary>
        /// <returns name="string">string</returns>
        #region Helpers
        [NonAction]
        public string GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.Claims.Skip(1).FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);


            var userId = claim.Value;
            return userId;
        }

        /// <summary>
        /// This method is used to validate all 
        /// attached files from the request body
        /// </summary>
        /// <param name="files"></param>
        /// <returns>Returns a dictionary</returns>
        [NonAction]
        public Dictionary<string, string> HandleFileValidation(IFormFileCollection files)
        {
            var errors = new Dictionary<string, string>();
            var invalidFiles = new List<IFormFile>();

            if (files.Count > 0)
            {

                for (int i = 0; i < files.Count; i++)
                {
                    if (files[i] != null && files[i].Length > 0)
                    {
                        var extension = Path.GetExtension(files[i].FileName);
                        string fileFormat = Configuration["FileFormat"];
                        long fileSize = long.Parse(Configuration["FileSize"]);

                        if (!fileFormat.Contains(extension.ToLower()))
                        {
                            errors.Add($"File[{Array.IndexOf(files.ToArray(), files[i])}]", $"{Path.GetFileNameWithoutExtension(files[i].FileName)} file failed to upload");
                            invalidFiles.Add(files[i]);
                        }

                        if (fileSize < files[i].Length)
                        {
                            errors.Add($"File[{Array.IndexOf(files.ToArray(), files[i])}]", $"{Path.GetFileNameWithoutExtension(files[i].FileName)} file size is should not be more than 10mb");
                            invalidFiles.Add(files[i]);
                        }
                    }
                }
            }

            return errors;
        }

        /// <summary>
        /// This method is used to validate all the attached files
        /// </summary>
        /// <param name="fileAttachments">DailyReportingFileAttachmentsDTO</param>
        /// <returns>Returns a dictionary of errors</returns>
        [NonAction]
        public Dictionary<string, string> HandleFileValidationDecision(DailyReportingFileAttachmentsDTO fileAttachments)
        {
            var errors = new Dictionary<string, string>();

            PropertyInfo[] properties = typeof(DailyReportingFileAttachmentsDTO).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(fileAttachments) != null)
                {
                    errors = HandleFileValidation((IFormFileCollection)property.GetValue(fileAttachments));

                    if (errors.Count > 0)
                    {
                        return errors;
                    }
                }
            }

            return errors;
        }
        #endregion

        [HttpGet("departments", Name = "GetDepartments")]
        [ProducesResponseType(typeof(SucessResponse<PagedResponse<IEnumerable<TblDepartments>>>), 200)]
        public async Task<IActionResult> GetDepartments([FromQuery] ResourceParameters parameters)
        {
            var departments = await _siteReportRepository.GetDepartments(parameters);

            var prevLink = departments.HasPrevious ? CreateResourceUri(parameters, ResourceUriType.PreviousPage) : null;
            var nextLink = departments.HasNext ? CreateResourceUri(parameters, ResourceUriType.NextPage) : null;
            var currentLink = CreateResourceUri(parameters, ResourceUriType.CurrentPage);

            var pagination = new Pagination
            {
                currentPage = currentLink,
                nextPage = nextLink,
                previousPage = prevLink,
                totalPages = departments.TotalPages,
                perPage = departments.PageSize,
                totalEntries = departments.TotalCount
            };

            return Ok(new PagedResponse<IEnumerable<TblDepartments>>
            {
                success = true,
                message = "Departments retrieved successfully",
                data = departments,
                meta = new Meta
                {
                    pagination = pagination
                }
            });
        }

        /// <summary>
        /// This action method handles the creation of 
        /// daily site reports
        /// </summary>
        /// <param name="dailyReportForm"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [DisableRequestSizeLimit]
        [ProducesResponseType(typeof(SucessResponse<object>), 200)]
        [ProducesResponseType(typeof(ErrorResponse<Dictionary<string, string[]>>), 400)]
        [ProducesResponseType(typeof(ErrorResponse<object>), 404)]
        public async Task<IActionResult> CreateDailySiteReport([FromForm] DailyReportFormDTO dailyReportForm)
        {
            try
            {
                var userId = GetUserId();

                if (!ModelState.IsValid)
                {
                    return BadRequest(new ErrorResponse<Dictionary<string, string[]>>
                    {
                        success = false,
                        message = "Your site reporting creation request failed",
                        errors = ModelState.Error().FilterError()
                    });
                }

                var workflowDef = await _tblWorkflowProcessDef.ExistsAsync(x => x.WfdefId == 12);

                if (!workflowDef)
                {
                    return NotFound(new ErrorResponse<object>
                    {
                        success = false,
                        message = "Workflow defination ID is not found",
                        errors = new { }
                    });
                }

                var dailyReportEntity = new TblSrdailyReportingTemp
                {
                    ProjectId = dailyReportForm.ProjectId,
                    GeneralSummary = dailyReportForm.GeneralSummary,
                    ConstructionActivities = dailyReportForm.ConstructionActivities,
                    DailyProgress = dailyReportForm.DailyProgress,
                    FollowingDayPlan = dailyReportForm.FollowingDayPlan,
                    ProgressAt = dailyReportForm.ProgressAt,
                    ConstructionActual = dailyReportForm.ConstructionActual,
                    Planned = dailyReportForm.Planned,
                    CreatedDate = DateTime.Now,
                    CreatedBy = userId,
                };

                var dailyReport = await _tblSrdailyReportingTemp.CreateAsync(dailyReportEntity);
                await _tblSrdailyReportingTemp.SaveChangesAsync();

                if (!dailyReport)
                {
                    return BadRequest(new ErrorResponse<Dictionary<string, string[]>>
                    {
                        success = false,
                        message = "Your site reporting creation request failed",
                        errors = ModelState.Error()
                    });
                }

                if (dailyReportForm.HSEReport != null && dailyReportForm.HSEReport.Count > 0)
                {
                    var hseReportList = new List<TblSrdailyReportHsetemp>();

                    foreach (var hseReport in dailyReportForm.HSEReport)
                    {
                        hseReportList.Add(new TblSrdailyReportHsetemp
                        {
                            DailyRepId = dailyReportEntity.DailyRepId,
                            Title = hseReport.Title,
                            DetailsStatistics = hseReport.DetailStatistics,
                            Remarks = hseReport.Remarks,
                            CreatedDate = DateTime.Now,
                            CreatedBy = userId,
                        });
                    }
                    await _tblSrdailyReportHsetemp.AddRangeAsync(hseReportList);
                }

                if (dailyReportForm.DailyReportingProgressMeasurement != null && dailyReportForm.DailyReportingProgressMeasurement.Count > 0)
                {
                    var progressMeasurementList = new List<TblSrdailyReportProgressMeasurementTemp>();

                    foreach (var progressMeasurement in dailyReportForm.DailyReportingProgressMeasurement)
                    {
                        progressMeasurementList.Add(new TblSrdailyReportProgressMeasurementTemp
                        {
                            DailyRepId = dailyReportEntity.DailyRepId,
                            Activity = progressMeasurement.Activity,
                            CumProgressActual = progressMeasurement.CumProgressActual,
                            CumPlannedProgress = progressMeasurement.CumPlannedProgress,
                            Remarks = progressMeasurement.Remarks,
                            CreatedDate = DateTime.Now,
                            CreatedBy = userId
                        });
                    }

                    await _tblSrdailyReportProgressMeasurementTemp.AddRangeAsync(progressMeasurementList);
                }

                if (dailyReportForm.DailyReportingIssues != null && dailyReportForm.DailyReportingIssues.Count > 0)
                {
                    var issuesList = new List<TblSrdailyReportingIssuesTemp>();

                    foreach (var issue in dailyReportForm.DailyReportingIssues)
                    {
                        issuesList.Add(new TblSrdailyReportingIssuesTemp
                        {
                            DailyRepId = dailyReportEntity.DailyRepId,
                            Challenges = issue.Challenges,
                            Recommendations = issue.Recommendations,
                            CreatedDate = DateTime.Now,
                            CreatedBy = userId
                        });
                    }
                    await _tblSrdailyReportingIssuesTemp.AddRangeAsync(issuesList);
                }

                if (dailyReportForm.DailyReportingDelays != null && dailyReportForm.DailyReportingDelays.Count > 0)
                {
                    var delayList = new List<TblSrdailyReportingDelaysTemp>();

                    foreach (var delay in dailyReportForm.DailyReportingDelays)
                    {
                        delayList.Add(new TblSrdailyReportingDelaysTemp
                        {
                            DailyRepId = dailyReportEntity.DailyRepId,
                            DescriptionofDelay = delay.DescriptionOfDelay,
                            TimeTaken = delay.TimeTaken,
                            Cause = delay.Cause,
                            Responsible = delay.Responsible,
                            CreatedDate = DateTime.Now,
                            CreatedBy = userId
                        });
                    }

                    await _tblSrdailyReportingDelaysTemp.AddRangeAsync(delayList);
                }

                if (dailyReportForm.DailyReportingFileAttachments != null)
                {
                    var errors = HandleFileValidationDecision(dailyReportForm.DailyReportingFileAttachments);

                    if (errors.Count > 0)
                    {
                        return BadRequest(new ErrorResponse<object>
                        {
                            success = false,
                            message = "Something went wrong with the uploaded files",
                            errors = errors
                        });
                    }
                }

                var fileContentList = new List<byte[]>();
                var fileObjectList = new List<FileObject>();
                var files = string.Empty;
                var fileObjects = string.Empty;
                if (dailyReportForm.DailyReportingFileAttachments != null)
                {
                    var attachments = dailyReportForm.DailyReportingFileAttachments;

                    PropertyInfo[] properties = typeof(DailyReportingFileAttachmentsDTO).GetProperties();
                    foreach (var property in properties)
                    {
                        var propValue = property.GetValue(attachments);
                        if (property.GetValue(attachments) != null)
                        {
                            var fileObj = await ProcessFileContents((IFormFileCollection)property.GetValue(attachments), dailyReportEntity.DailyRepId);

                            var serializedFileObj = JsonConvert.SerializeObject(fileObj);

                            var jobId = BackgroundJob.Enqueue(() => ProcessFileUpload(property.Name, serializedFileObj));
                        }
                    }
                }

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

                var (checker, approver) = await _siteReportRepository.GetWorkflowApprovers(12);

                await _emailSender.SendEmailAsync(checker, "Daily Site Report tendered", "Log in to check the reports");
                await _emailSender.SendEmailAsync(approver, "Daily Site Report tendered", "Log in to check the reports");

                var newAudit = new TblAuthList
                {
                    Title = "SiteReporting",
                    Url = "api/v1/sitereporting/getallforms",
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);
                await _auditRepository.SaveChangesAsync();

                return Ok(new SucessResponse<object>
                {
                    success = true,
                    message = "Site Report created successfully",
                    data = new { }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, Response<string>.InternalError(ex.Message));
            }
        }

        /// <summary>
        /// This method is used to create a technical query
        /// </summary>
        /// <param name="technicalQueriesDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTechnicalQueries([FromForm] TechnicalQueriesFormDto technicalQueriesDto)
        {
            var userId = GetUserId();
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            var country = await _tblCountry.ExistsAsync(x => x.CountryId == technicalQueriesDto.CountryId);
            var state = await _tblState.ExistsAsync(x => x.StateId == technicalQueriesDto.StateId);
            var city = await _tblCity.ExistsAsync(x => x.CityId == technicalQueriesDto.CityId);
            var project = await _tblProject.FirstOrDefaultAsync(x => x.ProjectId == technicalQueriesDto.ProjectId);
            var attendee = await _staffRepository.FirstOrDefaultAsync(x => x.StaffId == technicalQueriesDto.AttendeeId);


            var company = await _tblCompanyInfo.FirstOrDefaultAsync(x => x.CompanyId == tblStaff.CompanyId);
            var raisedDate = $"{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}";

            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse<Dictionary<string, string[]>>
                {
                    success = false,
                    message = "Your construction technical query request failed",
                    errors = ModelState.Error().FilterError()
                });
            }

            if (project == null)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"Project with ID: {technicalQueriesDto.ProjectId} is not found",
                    errors = new { }
                });
            }
            var projectName = project.ProjectName.ToUpper() ?? "NAME";


            if (!Enum.IsDefined(typeof(EPriority), technicalQueriesDto.Priority))
            {
                return BadRequest(new ErrorResponse<Dictionary<string, string[]>>
                {
                    success = false,
                    message = "Your construction technical query request failed",
                    errors = new Dictionary<string, string[]>
                    {
                        { "priority", new string[] {"Priority should be 0, 1 or 2"} }
                    }
                });
            }

            if (tblStaff == null)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"Staff with ID: {userId} is not found",
                    errors = new { }
                });
            }

            if (!country)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"Country with ID: {technicalQueriesDto.CountryId} is not found",
                    errors = new { }
                });
            }

            if (!state)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"State with ID: {technicalQueriesDto.StateId} is not found",
                    errors = new { }
                });
            }

            if (!city)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"City with ID: {technicalQueriesDto.CityId} is not found",
                    errors = new { }
                });
            }

            if (attendee == null)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"Staff with ID: {technicalQueriesDto.AttendeeId} is not found",
                    errors = new { }
                });
            }

            if (project == null)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"Project with ID: {technicalQueriesDto.ProjectId} is not found",
                    errors = new { }
                });
            }

            if (company == null)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"Company with ID: {tblStaff.CompanyId} is not found",
                    errors = new { }
                });
            }

            var file = technicalQueriesDto.DrawingFile;
            string fileFormat = Configuration["FileFormat"];
            long fileSize = long.Parse(Configuration["FileSize"]);

            if (file != null && file.Length > 0)
            {
                var extension = Path.GetExtension(file.FileName);

                if (!fileFormat.Contains(extension.ToLower()))
                {
                    return BadRequest(new ErrorResponse<object>
                    {
                        success = false,
                        message = "Your construction technical query request failed",
                        errors = new
                        {
                            file = new string[] { "The file type is not recognized" }
                        }
                    });
                }

                if (fileSize < file.Length)
                {
                    return BadRequest(new ErrorResponse<object>
                    {
                        success = false,
                        message = "Your construction technical query request failed",
                        errors = new
                        {
                            file = new string[] { "File size cannot be bigger than 10 megabytes" }
                        }
                    });
                }
            }
                        
            var technicalQueries = _mapper.Map<TblSrconstructionTechnicalQueriesTemp>(technicalQueriesDto);

            technicalQueries.StaffId = tblStaff.StaffId;
            technicalQueries.CreatedBy = tblStaff.StaffId.ToString();
            technicalQueries.CreatedDate = DateTime.Now;

            await _tblSrContructionTechnicalQueries.CreateAsync(technicalQueries);
            await _tblSrContructionTechnicalQueries.SaveChangesAsync();

            var technicalQueryReplies = new TblSrconstructionTechnicalQueryRepliesTemp
            {
                Ctqid = technicalQueries.Ctqid,
                CreatedBy = tblStaff.StaffId.ToString(),
                CreatedDate = DateTime.Now
            };

            await _tblSrconstructionTechnicalQueryRepliesTemp.CreateAsync(technicalQueryReplies);
            await _tblSrconstructionTechnicalQueryRepliesTemp.SaveChangesAsync();

            if (file != null && file.Length > 0)
            {
                var companyCode = company.CompanyCode ?? "DGS";
                var fileObj = await ProcessFileContent(file, technicalQueries.Ctqid);
                fileObj.ReferenceNumber = $"{companyCode.ToUpper()}/{projectName}/{"CTQ"}/{raisedDate}/{technicalQueries.Ctqid + 1}";

                var serializedFileObj = JsonConvert.SerializeObject(fileObj);

                var jobId = BackgroundJob.Enqueue(() => ProcessFileUploadForTechnicalQueries("technicalqueries", serializedFileObj));
            }

            var emailAddress = attendee.OfficeEmailAddress;

            await _emailSender.SendEmailAsync(emailAddress, "Construction technical query is created", "Log in to check the reports");

            return Ok(new SucessResponse<object>
            {
                success = true,
                message = "Construction Technical query created successfully",
                data = new { }
            });
        }

        /// <summary>
        /// This method is used to reply the construction technical
        /// queries created by the initiator
        /// </summary>
        /// <param name="attentionReply"></param>
        /// <param name="ctqId"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> AttentionReply(AttentionReplyFormDto attentionReply, int ctqId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse<Dictionary<string, string[]>>
                {
                    success = false,
                    message = "Your construction technical query request failed",
                    errors = ModelState.Error().FilterError()
                });
            }

            var userId = GetUserId();
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            if (tblStaff == null)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"Attention with ID: {userId} is not found",
                    errors = new { }
                });
            }

            if (attentionReply.AttentionDate < DateTime.Now)
            {
                return BadRequest(new ErrorResponse<Dictionary<string, string[]>>
                {
                    success = false,
                    message = "Your construction technical query request failed",
                    errors = new Dictionary<string, string[]>
                    {
                        { "attentionDate", new string[] {"Attention date should not be less than today"} } 
                    }
                });
            }

            var ctqEntity = await _tblSrContructionTechnicalQueries.FirstOrDefaultAsync(x => x.Ctqid == ctqId);

            if (ctqEntity == null)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"Construction technical query with ID: {ctqId} is not found",
                    errors = new { }
                });
            }

            if (ctqEntity.Attention != tblStaff.StaffId)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"This staff with ID {ctqId} is not assigned to attend to this report",
                    errors = new { }
                });
            }

            var replyEntity = await _tblSrconstructionTechnicalQueryRepliesTemp.FirstOrDefaultAsync(x => x.Ctqid == ctqId);

            if (replyEntity == null)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"CTQ reply with CtqId of {ctqId} is not found",
                    errors = new { }
                });
            }

            replyEntity.AttentionReply = attentionReply.AttentionReply;
            replyEntity.AttentionReplyDate = attentionReply.AttentionDate.Year;
            replyEntity.ModifiedBy = tblStaff.StaffId.ToString();
            replyEntity.ModifiedDate = DateTime.Now;

            _tblSrconstructionTechnicalQueryRepliesTemp.Update(replyEntity);
            await _tblSrconstructionTechnicalQueryRepliesTemp.SaveChangesAsync();

            var initiator = await _staffRepository.FirstOrDefaultAsync(x => x.StaffId == ctqEntity.StaffId);

            await _emailSender.SendEmailAsync(initiator.OfficeEmailAddress, "Attendee Reply", "An Attendee replied one of your queries");

            return Ok(new SucessResponse<object>
            {
                success = true,
                message = "Construction technical query reply updated successfully",
                data = new { }
            });
        }

        /// <summary>
        /// This method is used to reply construction technical
        /// queries by the initiator
        /// </summary>
        /// <param name="initiatorReply"></param>
        /// <param name="ctqId"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> InitiatorReply(InitiatorReplyFormDto initiatorReply, int ctqId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse<Dictionary<string, string[]>>
                {
                    success = false,
                    message = "Your construction technical query request failed",
                    errors = ModelState.Error().FilterError()
                });
            }

            if (!Enum.IsDefined(typeof(EInitiatorAcceptance), initiatorReply.InitiatorAcceptance))
            {
                return BadRequest(new ErrorResponse<Dictionary<string, string[]>>
                {
                    success = false,
                    message = "Your construction technical query request failed",
                    errors = new Dictionary<string, string[]>
                    {
                        { "initiatorAcceptance", new string[] {"Initiator's acceptance should be 0, 1 or 2"} }
                    }
                });
            }

            var userId = GetUserId();
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            if (tblStaff == null)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"Initiator with ID: {userId} is not found",
                    errors = new { }
                });
            }

            if (initiatorReply.InitiatorReplyDate < DateTime.Now)
            {
                return BadRequest(new ErrorResponse<Dictionary<string, string[]>>
                {
                    success = false,
                    message = "Your construction technical query request failed",
                    errors = new Dictionary<string, string[]>
                    {
                        { "initiatorReplyDate", new string[] {"Initail reply date should not be greater than today"} }
                    }
                });
            }

            var ctqEntity = await _tblSrContructionTechnicalQueries.FirstOrDefaultAsync(x => x.Ctqid == ctqId);

            if (ctqEntity == null)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"Construction technical query with ID: {ctqId} is not found",
                    errors = new { }
                });
            }

            if (ctqEntity.StaffId != tblStaff.StaffId)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"This staff with ID {ctqId} is not the initiator of this report",
                    errors = new { }
                });
            }

            var replyEntity = await _tblSrconstructionTechnicalQueryRepliesTemp.FirstOrDefaultAsync(x => x.Ctqid == ctqId);

            if (replyEntity == null)
            {
                return NotFound(new ErrorResponse<object>
                {
                    success = false,
                    message = $"CTQ reply with CtqId of {ctqId} is not found",
                    errors = new { }
                });
            }

            replyEntity.InitiatorAcceptance = initiatorReply.InitiatorAcceptance;
            replyEntity.InitiatorReply = initiatorReply.InitiatorReply;
            replyEntity.InitiatorReplyDate = initiatorReply.InitiatorReplyDate;
            replyEntity.ModifiedBy = tblStaff.StaffId.ToString();
            replyEntity.ModifiedDate = DateTime.Now;

            _tblSrconstructionTechnicalQueryRepliesTemp.Update(replyEntity);
            await _tblSrconstructionTechnicalQueryRepliesTemp.SaveChangesAsync();

            var attention = await _staffRepository.FirstOrDefaultAsync(x => x.StaffId == ctqEntity.Attention);

            await _emailSender.SendEmailAsync(attention.OfficeEmailAddress, "Initiator Reply", "An Initiator has responded to one of your queries");

            if ((int)EInitiatorAcceptance.Approve == initiatorReply.InitiatorAcceptance)
            {
                var (checker, approver) = await _siteReportRepository.GetWorkflowApprovers(11);

                await _emailSender.SendEmailAsync(checker, "Construction technical report", "Log in to check the reports");
                await _emailSender.SendEmailAsync(approver, "Construction technical report", "Log in to check the reports");

                await _emailSender.SendEmailAsync(attention.OfficeEmailAddress, "Initiator Reply", "Your construction technical query has been approved");

                var newAudit = new TblAuthList
                {
                    Title = "SiteReporting",
                    Url = "api/v1/sitereporting/initiatorreply",
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);
                await _auditRepository.SaveChangesAsync();
            }

            return Ok(new SucessResponse<object>
            {
                success = true,
                message = "Construction technical query reply updated successfully",
                data = new { }
            });
        }


        /// <summary>
        /// This method is used to process the contents of the 
        /// files, creating an object out of the process file
        /// </summary>
        /// <param name="formFiles"></param>
        /// <param name="id"></param>
        /// <returns>List of file objects</returns>
        [NonAction]
        public async Task<List<FileObject>> ProcessFileContents(IFormFileCollection formFiles, int id)
        {
            var userId = GetUserId();
            var fileObjectList = new List<FileObject>();
            for (int i = 0; i < formFiles.Count; i++)
            {
                using var memoryStream = new MemoryStream();
                await formFiles[i].CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();

                fileObjectList.Add(new FileObject
                {
                    Id = id,
                    ContentType = formFiles[i].ContentType,
                    Extension = Path.GetExtension(formFiles[i].FileName),
                    ContentFileName = Path.GetFileNameWithoutExtension(formFiles[i].FileName),
                    CreatedBy = userId,
                    File = content
                });
            }

            return fileObjectList;
        }

        /// <summary>
        /// This method is used to process each file's content
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [NonAction]
        public async Task<FileObject> ProcessFileContent(IFormFile formFile, int id)
        {
            var userId = GetUserId();

            using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            var content = memoryStream.ToArray();

            var fileObject = new FileObject
            {
                Id = id,
                ContentType = formFile.ContentType,
                Extension = Path.GetExtension(formFile.FileName),
                ContentFileName = Path.GetFileNameWithoutExtension(formFile.FileName),
                CreatedBy = userId,
                File = content
            };

            return fileObject;
        }



        /// <summary>
        /// This method is used to upload the file to 
        /// Azure blob storage. It is used by Hangfire
        /// for background processes
        /// </summary>
        /// <param name="saveTo">What column to save to in the table</param>
        /// <param name="objs">The string to serialize from into a object</param>
        /// <returns></returns>
        [NonAction]
        [AutomaticRetry(Attempts = 2)]
        public async Task ProcessFileUpload(string saveTo, string objs)
        {
            var dailyAttachments = new List<TblSrdailyReportFileAttachmentsTemp>();
            var fileObject = JsonConvert.DeserializeObject<List<FileObject>>(objs);

            foreach (var file in fileObject)
            {
                var fileResult = await _uploadFile.UploadFile(
                    saveTo.ToLower(), file.File, 
                    file.Extension, 
                    file.ContentType, 
                    file.ContentFileName);

                var tblSrdaily = new TblSrdailyReportFileAttachmentsTemp();

                tblSrdaily.DailyRepId = file.Id;
                tblSrdaily.CreatedBy = file.CreatedBy;
                tblSrdaily.CreatedDate = DateTime.Now;
                tblSrdaily.GetType().GetProperty(saveTo).SetValue(tblSrdaily, fileResult.Url, null);


                dailyAttachments.Add(tblSrdaily);
            }

            await _tblSrdailyReportFileAttachmentsTemp.AddRangeAsync(dailyAttachments);
            await _tblSrdailyReportFileAttachmentsTemp.SaveChangesAsync();
        }

        [NonAction]
        [AutomaticRetry(Attempts = 2)]
        public async Task ProcessFileUploadForTechnicalQueries(string containerName, string objs)
        {
            var fileObject = JsonConvert.DeserializeObject<FileObject>(objs);

            var fileResult = await _uploadFile.UploadFile(
                    containerName.ToLower(), fileObject.File,
                    fileObject.Extension,
                    fileObject.ContentType,
                    fileObject.ContentFileName);

            var entity = new TblSrconstructionTechnicalQueryAttachmentsTemp();

            entity.Ctqid = fileObject.Id;
            entity.CreatedBy = fileObject.CreatedBy;
            entity.CreatedDate = DateTime.Now;
            entity.DrawingFile = fileResult.Url;
            entity.ReferenceNumber = fileObject.ReferenceNumber;

            await _tblSrconstructionTechnicalQueryAttachmentsTemp.CreateAsync(entity);
            await _tblSrconstructionTechnicalQueryAttachmentsTemp.SaveChangesAsync();
        }

        /// <summary>
        /// Used for hold a serialize object of file
        /// contents
        /// </summary>
        public class FileObject
        {
            public string ContentType { get; set; }
            public string Extension { get; set; }
            public string ContentFileName { get; set; }
            public int Id { get; set; }
            public string CreatedBy { get; set; }
            public byte[] File { get; set; }
            public string ReferenceNumber { get; set; }
        }
        #region CreateResource
        private string CreateResourceUri(ResourceParameters parameters, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetDepartments",
                        new
                        {
                            PageNumber = parameters.PageNumber - 1,
                            parameters.PageSize,
                        });

                case ResourceUriType.NextPage:
                    return Url.Link("GetDepartments",
                        new
                        {
                            PageNumber = parameters.PageNumber + 1,
                            parameters.PageSize,
                        });

                default:
                    return Url.Link("GetDepartments",
                        new
                        {
                            parameters.PageNumber,
                            parameters.PageSize,
                        });
            }

        }
        #endregion
    }
}
