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
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JPSAGE_ERP.WebAPI.Controllers
{
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
        private readonly IOptions<FileSettings> _fileSettings;
        private readonly IUploadFileToBlob _uploadFile;

        public SiteReportingController(
                IRepository<TblSrdailyReportingTemp> tblSrdailyReportingTemp,
                IRepository<TblSrdailyReportHsetemp> tblSrdailyReportHsetemp,
                IRepository<TblSrdailyReportFileAttachmentsTemp> tblSrdailyReportFileAttachmentsTemp,
                IRepository<TblSrdailyReportProgressMeasurementTemp> tblSrdailyReportProgressMeasurementTemp,
                IRepository<TblSrdailyReportingIssuesTemp> tblSrdailyReportingIssuesTemp,
                IRepository<TblSrdailyReportingDelaysTemp> tblSrdailyReportingDelaysTemp,
                IRepository<TblCodeGenerator> codeGeneratorRepository,
                IRepository<TblAuthList> auditRepository,
                IRepository<TblStaffBioData> staffRepository,
                IOptions<FileSettings> fileSettings,
                IUploadFileToBlob uploadFile,
                IConfiguration configuration
            )
        {
            _tblSrdailyReportingTemp = tblSrdailyReportingTemp;
            _tblSrdailyReportHsetemp = tblSrdailyReportHsetemp;
            _tblSrdailyReportFileAttachmentsTemp = tblSrdailyReportFileAttachmentsTemp;
            _tblSrdailyReportProgressMeasurementTemp = tblSrdailyReportProgressMeasurementTemp;
            _tblSrdailyReportingIssuesTemp = tblSrdailyReportingIssuesTemp;
            _tblSrdailyReportingDelaysTemp = tblSrdailyReportingDelaysTemp;
            _auditRepository = auditRepository;
            _staffRepository = staffRepository;
            _codeGeneratorRepository = codeGeneratorRepository;
            _fileSettings = fileSettings;
            _uploadFile = uploadFile;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // generally used methods
        #region Helpers
        [NonAction]
        public string GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.Claims.Skip(1).FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);


            var userId = claim.Value;
            return userId;
        }

        [NonAction]
        public async Task<string> GetAuthorizerCode()
        {
            var codeGenerator = await _codeGeneratorRepository.FirstOrDefaultAsync(x => x.Status == 0);

            return codeGenerator.GeneratedCode;
        }

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

        [NonAction]
        public Dictionary<string, string> HandleFileValidationDecision(DailyReportingFileAttachmentsDTO fileAttachments)
        {
            var errors = new Dictionary<string, string>();

            if (fileAttachments != null)
            {
                if (fileAttachments.PermitToWork != null && fileAttachments.PermitToWork.Count > 0)
                {
                    errors = HandleFileValidation(fileAttachments.PermitToWork);

                    if (errors.Count > 0)
                    {
                        return errors;
                    }
                }

                if (fileAttachments.SecurityReport != null && fileAttachments.SecurityReport.Count > 0)
                {
                    errors = HandleFileValidation(fileAttachments.SecurityReport);

                    if (errors.Count > 0)
                    {
                        return errors;
                    }
                }

                if (fileAttachments.ProgressPictures != null && fileAttachments.ProgressPictures.Count > 0)
                {
                    errors = HandleFileValidation(fileAttachments.ProgressPictures);

                    if (errors.Count > 0)
                    {
                        return errors;
                    }
                }

                if (fileAttachments.QAQCReport != null && fileAttachments.QAQCReport.Count > 0)
                {
                    errors = HandleFileValidation(fileAttachments.QAQCReport);

                    if (errors.Count > 0)
                    {
                        return errors;
                    }
                }

                if (fileAttachments.LogisticReport != null && fileAttachments.LogisticReport.Count > 0)
                {
                    errors = HandleFileValidation(fileAttachments.LogisticReport);

                    if (errors.Count > 0)
                    {
                        return errors;
                    }
                }

                if (fileAttachments.SitePersonnelLogReport != null && fileAttachments.SitePersonnelLogReport.Count > 0)
                {
                    errors = HandleFileValidation(fileAttachments.PermitToWork);

                    if (errors.Count > 0)
                    {
                        return errors;
                    }
                }

                if (fileAttachments.MaterialReport != null && fileAttachments.MaterialReport.Count > 0)
                {
                    errors = HandleFileValidation(fileAttachments.MaterialReport);

                    if (errors.Count > 0)
                    {
                        return errors;
                    }
                }

                if (fileAttachments.MocReport != null && fileAttachments.MocReport.Count > 0)
                {
                    errors = HandleFileValidation(fileAttachments.MocReport);

                    if (errors.Count > 0)
                    {
                        return errors;
                    }
                }
            }

            return errors;
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> CreateDailySiteReport([FromForm] DailyReportFormDTO dailyReportForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse<Dictionary<string, string[]>>
                { 
                    success = false,
                    message = "Your site reporting creation request failed",
                    errors = ModelState.Error().FilterError()
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
                CreatedBy = GetUserId(),
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

            if (dailyReportForm.HSEReport.Count > 0)
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
                        CreatedBy = GetUserId()
                    });
                }
                await _tblSrdailyReportHsetemp.AddRangeAsync(hseReportList);
            }

            if (dailyReportForm.DailyReportingProgressMeasurement.Count > 0)
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
                        CreatedBy = GetUserId()
                    });
                }

                await _tblSrdailyReportProgressMeasurementTemp.AddRangeAsync(progressMeasurementList);
            }

            if (dailyReportForm.DailyReportingIssues.Count > 0)
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
                        CreatedBy = GetUserId()
                    });
                }
                await _tblSrdailyReportingIssuesTemp.AddRangeAsync(issuesList);
            }

            if (dailyReportForm.DailyReportingDelays.Count > 0)
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
                        CreatedBy = GetUserId()
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

                if (attachments.PermitToWork != null && attachments.PermitToWork.Count > 0)
                {
                    var fileObj = await ProcessFileContents(attachments.PermitToWork, dailyReportEntity.DailyRepId);

                    var serializedFileObj = JsonConvert.SerializeObject(fileObj);

                    await ProcessFileUpload(EDailySiteReport.PermitToWork.GetDescription(), serializedFileObj, attachments);
                }

                if (attachments.SecurityReport != null && attachments.SecurityReport.Count > 0)
                {
                    var fileObj = await ProcessFileContents(attachments.SecurityReport, dailyReportEntity.DailyRepId);

                    var serializedFileObj = JsonConvert.SerializeObject(fileObj);

                    await ProcessFileUpload(EDailySiteReport.SecurityReport.GetDescription(), serializedFileObj, attachments);
                }

                if (attachments.ProgressPictures != null && attachments.ProgressPictures.Count > 0)
                {
                    var fileObj = await ProcessFileContents(attachments.ProgressPictures, dailyReportEntity.DailyRepId);

                    var serializedFileObj = JsonConvert.SerializeObject(fileObj);

                    await ProcessFileUpload(EDailySiteReport.ProgressPictures.GetDescription(), serializedFileObj, attachments);
                }

                if (attachments.QAQCReport != null && attachments.QAQCReport.Count > 0)
                {
                    var fileObj = await ProcessFileContents(attachments.QAQCReport, dailyReportEntity.DailyRepId);

                    var serializedFileObj = JsonConvert.SerializeObject(fileObj);

                    await ProcessFileUpload(EDailySiteReport.QAQCReport.GetDescription(), serializedFileObj, attachments);
                }

                if (attachments.LogisticReport != null && attachments.LogisticReport.Count > 0)
                {
                    var fileObj = await ProcessFileContents(attachments.LogisticReport, dailyReportEntity.DailyRepId);

                    var serializedFileObj = JsonConvert.SerializeObject(fileObj);

                    await ProcessFileUpload(EDailySiteReport.LogisticReport.GetDescription(), serializedFileObj, attachments);
                }

                if (attachments.SitePersonnelLogReport != null && attachments.SitePersonnelLogReport.Count > 0)
                {
                    var fileObj = await ProcessFileContents(attachments.SitePersonnelLogReport, dailyReportEntity.DailyRepId);

                    var serializedFileObj = JsonConvert.SerializeObject(fileObj);

                    await ProcessFileUpload(EDailySiteReport.SitePersonnelLogReport.GetDescription(), serializedFileObj, attachments);
                }

                if (attachments.MaterialReport != null && attachments.MaterialReport.Count > 0)
                {
                    var fileObj = await ProcessFileContents(attachments.MaterialReport, dailyReportEntity.DailyRepId);

                    var serializedFileObj = JsonConvert.SerializeObject(fileObj);

                    await ProcessFileUpload(EDailySiteReport.MaterialReprot.GetDescription(), serializedFileObj, attachments);
                }

                if (attachments.MocReport != null && attachments.MocReport.Count > 0)
                {
                    var fileObj = await ProcessFileContents(attachments.MocReport, dailyReportEntity.DailyRepId);

                    var serializedFileObj = JsonConvert.SerializeObject(fileObj);

                    await ProcessFileUpload(EDailySiteReport.MOCReport.GetDescription(), serializedFileObj, attachments);
                }
            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == GetUserId());

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

        [NonAction]
        public async Task<List<FileObject>> ProcessFileContents(IFormFileCollection formFiles, int id)
        {
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
                    CreatedBy = GetUserId(),
                    File = content
                });
            }

            return fileObjectList;
        }

        [NonAction]
        public async Task ProcessFileUpload(string saveTo, string objs, DailyReportingFileAttachmentsDTO attachments)
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

                if (saveTo.ToLower() == EDailySiteReport.PermitToWork.GetDescription().ToLower())
                {
                    dailyAttachments.Add(new TblSrdailyReportFileAttachmentsTemp
                    {
                        DailyRepId = file.DailyRepId,
                        PermitToWork = fileResult.Url,
                        CreatedDate = DateTime.Now,
                        CreatedBy = file.CreatedBy
                    });
                }

                if (saveTo.ToLower() == EDailySiteReport.SecurityReport.GetDescription().ToLower())
                {
                    dailyAttachments.Add(new TblSrdailyReportFileAttachmentsTemp
                    {
                        DailyRepId = file.DailyRepId,
                        SecurityReport = fileResult.Url,
                        CreatedDate = DateTime.Now,
                        CreatedBy = file.CreatedBy
                    });
                }

                if (saveTo.ToLower() == EDailySiteReport.ProgressPictures.GetDescription().ToLower())
                {
                    dailyAttachments.Add(new TblSrdailyReportFileAttachmentsTemp
                    {
                        DailyRepId = file.DailyRepId,
                        ProgressPictures = fileResult.Url,
                        CreatedDate = DateTime.Now,
                        CreatedBy = file.CreatedBy
                    });
                }

                if (saveTo.ToLower() == EDailySiteReport.QAQCReport.GetDescription().ToLower())
                {
                    dailyAttachments.Add(new TblSrdailyReportFileAttachmentsTemp
                    {
                        DailyRepId = file.DailyRepId,
                        Qaqcreport = fileResult.Url,
                        CreatedDate = DateTime.Now,
                        CreatedBy = file.CreatedBy
                    });
                }

                if (saveTo.ToLower() == EDailySiteReport.LogisticReport.GetDescription().ToLower())
                {
                    dailyAttachments.Add(new TblSrdailyReportFileAttachmentsTemp
                    {
                        DailyRepId = file.DailyRepId,
                        LogisticsReport = fileResult.Url,
                        CreatedDate = DateTime.Now,
                        CreatedBy = file.CreatedBy
                    });
                }

                if (saveTo.ToLower() == EDailySiteReport.SitePersonnelLogReport.GetDescription().ToLower())
                {
                    dailyAttachments.Add(new TblSrdailyReportFileAttachmentsTemp
                    {
                        DailyRepId = file.DailyRepId,
                        SitePersonnelLogReport = fileResult.Url,
                        CreatedDate = DateTime.Now,
                        CreatedBy = file.CreatedBy
                    });
                }

                if (saveTo.ToLower() == EDailySiteReport.MaterialReprot.GetDescription().ToLower())
                {
                    dailyAttachments.Add(new TblSrdailyReportFileAttachmentsTemp
                    {
                        DailyRepId = file.DailyRepId,
                        MaterialReport = fileResult.Url,
                        CreatedDate = DateTime.Now,
                        CreatedBy = file.CreatedBy
                    });
                }

                if (saveTo.ToLower() == EDailySiteReport.MOCReport.GetDescription().ToLower())
                {
                    dailyAttachments.Add(new TblSrdailyReportFileAttachmentsTemp
                    {
                        DailyRepId = file.DailyRepId,
                        Mocreport = fileResult.Url,
                        CreatedDate = DateTime.Now,
                        CreatedBy = file.CreatedBy
                    });
                }
            }

            await _tblSrdailyReportFileAttachmentsTemp.AddRangeAsync(dailyAttachments);
            await _tblSrdailyReportFileAttachmentsTemp.SaveChangesAsync();
        }

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
