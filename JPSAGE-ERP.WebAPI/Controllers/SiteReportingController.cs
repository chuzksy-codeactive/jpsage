using Hangfire;
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
        private readonly IRepository<TblSrdailyReportFileAttachmentsTemp> _tblSrdailyReportFileAttachmentsTemp;
        private readonly IRepository<TblSrdailyReportProgressMeasurementTemp> _tblSrdailyReportProgressMeasurementTemp;
        private readonly IRepository<TblSrdailyReportingIssuesTemp> _tblSrdailyReportingIssuesTemp;
        private readonly IRepository<TblSrdailyReportingDelaysTemp> _tblSrdailyReportingDelaysTemp;
        private readonly IRepository<TblAuthList> _auditRepository;
        private readonly IRepository<TblStaffBioData> _staffRepository;
        private readonly IRepository<TblCodeGenerator> _codeGeneratorRepository;
        private readonly IRepository<TblWorkflowProcessDef> _tblWorkflowProcessDef;
        private readonly ISiteReportRepository _siteReportRepository;
        private readonly IUploadFileToBlob _uploadFile;
        private readonly IEmailSender _emailSender;


        /// <summary>
        /// The class construction with dependecny injections
        /// </summary>
        /// <param name="tblSrdailyReportingTemp"></param>
        /// <param name="tblSrdailyReportHsetemp"></param>
        /// <param name="tblSrdailyReportFileAttachmentsTemp"></param>
        /// <param name="tblSrdailyReportProgressMeasurementTemp"></param>
        /// <param name="tblSrdailyReportingIssuesTemp"></param>
        /// <param name="tblSrdailyReportingDelaysTemp"></param>
        /// <param name="tblWorkflowProcessDef"></param>
        /// <param name="codeGeneratorRepository"></param>
        /// <param name="auditRepository"></param>
        /// <param name="staffRepository"></param>
        /// <param name="uploadFile"></param>
        /// <param name="configuration"></param>
        /// <param name="siteReportRepository"></param>
        /// <param name="emailSender"></param>
        public SiteReportingController(
                IRepository<TblSrdailyReportingTemp> tblSrdailyReportingTemp,
                IRepository<TblSrdailyReportHsetemp> tblSrdailyReportHsetemp,
                IRepository<TblSrdailyReportFileAttachmentsTemp> tblSrdailyReportFileAttachmentsTemp,
                IRepository<TblSrdailyReportProgressMeasurementTemp> tblSrdailyReportProgressMeasurementTemp,
                IRepository<TblSrdailyReportingIssuesTemp> tblSrdailyReportingIssuesTemp,
                IRepository<TblSrdailyReportingDelaysTemp> tblSrdailyReportingDelaysTemp,
                IRepository<TblWorkflowProcessDef> tblWorkflowProcessDef,
                IRepository<TblCodeGenerator> codeGeneratorRepository,
                IRepository<TblAuthList> auditRepository,
                IRepository<TblStaffBioData> staffRepository,
                IUploadFileToBlob uploadFile,
                IConfiguration configuration,
                ISiteReportRepository siteReportRepository,
                IEmailSender emailSender
            )
        {
            _tblSrdailyReportingTemp = tblSrdailyReportingTemp;
            _tblSrdailyReportHsetemp = tblSrdailyReportHsetemp;
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

        /// <summary>
        /// This action method handles the creation of 
        /// daily site reports
        /// </summary>
        /// <param name="dailyReportForm"></param>
        /// <returns></returns>
        [HttpPost]
        [DisableRequestSizeLimit]
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

                var workflowDef = await _tblWorkflowProcessDef.ExistsAsync(x => x.WfdefId == dailyReportForm.WFDefId);

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

                            BackgroundJob.Enqueue(() => ProcessFileUpload(property.Name, serializedFileObj));
                        }
                    }
                }

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

                var (checker, approver) = await _siteReportRepository.GetWorkflowApprovers(dailyReportForm.WFDefId);

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
        /// This method is used to process the contents of the 
        /// files, creating an object out of the process file
        /// </summary>
        /// <param name="formFiles"></param>
        /// <param name="id"></param>
        /// <returns></returns>
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
                    DailyRepId = id,
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
        /// This method is used to upload the file to 
        /// Azure blob storage. It is used by Hangfire
        /// for background processes
        /// </summary>
        /// <param name="saveTo">What column to save to in the table</param>
        /// <param name="objs">The string to serialize from into a object</param>
        /// <returns></returns>
        [NonAction]
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

                tblSrdaily.DailyRepId = file.DailyRepId;
                tblSrdaily.CreatedBy = file.CreatedBy;
                tblSrdaily.CreatedDate = DateTime.Now;
                tblSrdaily.GetType().GetProperty(saveTo).SetValue(tblSrdaily, fileResult.Url, null);


                dailyAttachments.Add(tblSrdaily);
            }

            await _tblSrdailyReportFileAttachmentsTemp.AddRangeAsync(dailyAttachments);
            await _tblSrdailyReportFileAttachmentsTemp.SaveChangesAsync();
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
            public int DailyRepId { get; set; }
            public string CreatedBy { get; set; }
            public byte[] File { get; set; }
        }
    }
}
