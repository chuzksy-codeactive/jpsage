using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JPSAGE_ERP.Application.Interfaces;
using JPSAGE_ERP.Application.Models.ApprovalWorkFlow;
using JPSAGE_ERP.Application.Models.JustificationOfAward;
using JPSAGE_ERP.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JPSAGE_ERP.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class JustificationOfAwardController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IRepository<TblWorkflowProcessDef> _workFlowRepository;
        private readonly IRepository<TblCodeGenerator> _codeGeneratorRepository;
        private readonly IEmailAddressRepository _emailAddressRepository;
        private readonly IRepository<TblStaffBioData> _staffRepository;
        private readonly IRepository<TblAuthList> _auditRepository;
        private readonly IRepository<TblAuthChecker> _authCheckerRepository;
        private readonly IRepository<TblAuthApprover> _authApproverRepository;
        private readonly IRepository<TblProjects> _projectsRepository;
        private readonly IRepository<TblQuotationMaster> _quotationMasterRepository;
        private readonly IRepository<TblSupplierIdentification> _supplierIdentificationRepository;
        private readonly IRepository<TblDepartments> _departmentsRepository;
        private readonly IRepository<TblJustificationofAward> _justificationOfAwardRepository;
        private readonly IRepository<TblSingleTenderJustification> _singleTenderJustificationRepository;

        public JustificationOfAwardController(
            IWebHostEnvironment hostingEnvironment,
            IRepository<TblWorkflowProcessDef> workFlowRepository,
            IRepository<TblCodeGenerator> codeGeneratorRepository,
            IEmailAddressRepository emailAddressRepository,
            IRepository<TblStaffBioData> staffRepository,
            IRepository<TblAuthList> auditRepository,
            IRepository<TblAuthChecker> authCheckerRepository,
            IRepository<TblAuthApprover> authApproverRepository,
            IRepository<TblProjects> projectsRepository,
            IRepository<TblQuotationMaster> quotationMasterRepository,
            IRepository<TblSupplierIdentification> supplierIdentificationRepository,
            IRepository<TblDepartments> departmentsRepository,
            IRepository<TblJustificationofAward> justificationOfAwardRepository,
            IRepository<TblSingleTenderJustification> singleTenderJustificationRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _workFlowRepository = workFlowRepository;
            _codeGeneratorRepository = codeGeneratorRepository;
            _emailAddressRepository = emailAddressRepository;
            _staffRepository = staffRepository;
            _auditRepository = auditRepository;
            _authCheckerRepository = authCheckerRepository;
            _authApproverRepository = authApproverRepository;
            _projectsRepository = projectsRepository;
            _quotationMasterRepository = quotationMasterRepository;
            _supplierIdentificationRepository = supplierIdentificationRepository;
            _departmentsRepository = departmentsRepository;
            _justificationOfAwardRepository = justificationOfAwardRepository;
            _singleTenderJustificationRepository = singleTenderJustificationRepository;
        }

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
        public async Task<int> GetEndPointId()
        {
            var tblWorflow = await _workFlowRepository.FirstOrDefaultAsync(x => x.WfdefId == 1);
            return tblWorflow.WfdefId;
        }


        [NonAction]
        public async Task<IActionResult> SendAuthorizerCode()
        {
            var endPointId = await _workFlowRepository.FirstOrDefaultAsync(x => x.WfdefId == 7);
            var codeGenerated = await _codeGeneratorRepository.FirstOrDefaultAsync(x => x.Status == 0);
            if (codeGenerated == null)
            {
                return NoContent();
            }

            var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId.WfdefId, 1);

            return Ok(new
            {
                EmailAddress = emailAddress,
                codeGenerated.GeneratedCode
            });
        }


        [NonAction]
        public string UploadFile(IFormFile formFile)
        {
            if (formFile != null)
            {
                // If the FormFile property on the incoming model object is not null, then the user
                // has selected an image to upload.


                // The image must be uploaded to the images folder in wwwroot
                // To get the path of the wwwroot folder we are using the inject
                // HostingEnvironment service provided by ASP.NET Core
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                // To make sure the file name is unique we are appending a new
                // GUID value and and an underscore to the file name
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                // Use CopyTo() method provided by IFormFile interface to
                // copy the file to wwwroot/images folder
                formFile.CopyTo(new FileStream(filePath, FileMode.Create));

                //assign vessel photo URL
                return uniqueFileName;
            }

            var returnUrl = "invalidfileUpload";
            return returnUrl;
        }
        #endregion

        // Justification Of Award

        [HttpGet("[action]")]
        public async Task<IActionResult> JustificationOfAwardForm()
        {
            var userId = GetUserId();

            var projects = await _projectsRepository.GetAllAsync();
            var quotationMasters = await _quotationMasterRepository.GetAllAsync();
            var suppliers = await _supplierIdentificationRepository.GetAllAsync();
            var departments = await _departmentsRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "Justification Of Award",
                Url = "/api/v1/justificationofaward/justificationofawardform",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(new
            {
                Projects = projects,
                QuotationMasters = quotationMasters,
                Suppliers = suppliers,
                Departments = departments
            });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateJustificationOfAward([FromBody] JustificationOfAwardFormModel model)
        {
            var userId = GetUserId();
            var endPointId = await GetEndPointId();

            if (ModelState.IsValid)
            {
                var justificationofAward = new TblJustificationofAward
                {
                    ProjectId = model.ProjectId,
                    Rqnnumber = model.Rqnnumber,
                    Rfqid = model.Rfqid,
                    SupplierId = model.SupplierId,
                    ScoreTechnicalEval = model.ScoreTechnicalEval,
                    VendorBidPrice = model.VendorBidPrice,
                    ScoreCommercialEval = model.ScoreCommercialEval,
                    EndUser = model.EndUser,
                    EndUserDepartmentId = model.EndUserDepartmentId,
                    Date = model.Date,
                    JustificationofAward = model.JustificationofAward,
                    CreatedDate = DateTime.Now,

                };

                await _justificationOfAwardRepository.CreateAsync(justificationofAward);


                // write logic to create TblAuthList object
                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "Justfication Of Award",
                    Url = "/api/v1/justificationofaward/createjustificationofaward",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);

                // login for email notification
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                await _auditRepository.SaveChangesAsync();

                return Ok(
                   new
                   {
                       message = "Justification of Award created successfully",
                       EmailAddress = emailAddress
                   });
            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }





        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateJustificationOfAward([FromBody] JustificationOfAwardFormModel model, [FromQuery] int justificationOfAwardId)
        {
            var userId = GetUserId();
            var endPointId = await GetEndPointId();

            if (ModelState.IsValid)
            {
                var justificationofAward = await _justificationOfAwardRepository.GetByIdAsync(justificationOfAwardId);

                if (justificationofAward == null)
                {
                    return NotFound(new { message = "Justification Of Award does not exist" });
                }


                // assign updated fields

                justificationofAward.ProjectId = model.ProjectId;
                justificationofAward.Rqnnumber = model.Rqnnumber;
                justificationofAward.Rfqid = model.Rfqid;
                justificationofAward.SupplierId = model.SupplierId;
                justificationofAward.ScoreTechnicalEval = model.ScoreTechnicalEval;
                justificationofAward.VendorBidPrice = model.VendorBidPrice;
                justificationofAward.ScoreCommercialEval = model.ScoreCommercialEval;
                justificationofAward.EndUser = model.EndUser;
                justificationofAward.EndUserDepartmentId = model.EndUserDepartmentId;
                justificationofAward.Date = model.Date;
                justificationofAward.JustificationofAward = model.JustificationofAward;


                _justificationOfAwardRepository.Update(justificationofAward);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

                // write logic to create TblAuthList object
                var newAudit = new TblAuthList
                {
                    Title = "Justfication Of Award",
                    Url = "/api/v1/justficationofaward/updatejustificationofaward",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);

                // login for email notification
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                await _auditRepository.SaveChangesAsync();

                return Ok(
                   new
                   {
                       message = "Justification Of Award updated successfully",
                       EmailAddress = emailAddress
                   });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetJustficationOfAward([FromQuery] int id)
        {
            var userId = GetUserId();

            var justificationofAward = await _justificationOfAwardRepository.GetByIdAsync(id);
            if (justificationofAward == null)
            {
                return NotFound("Justfication Of Award does not exist");
            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Justfication Of Award",
                Url = "/api/v1/justificationofaward/getjustification",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(justificationofAward);

        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllJustificationOfAward()
        {
            var userId = GetUserId();

            var justificationofAwards = await _justificationOfAwardRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Justification Of Award",
                Url = "/api/v1/justificationofaward/getalljustificationofaward",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(justificationofAwards);
        }


        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteJustificationOfAward([FromQuery] int id)
        {
            var userId = GetUserId();

            var justificationofAward = await _justificationOfAwardRepository.GetByIdAsync(id);
            if (justificationofAward == null)
            {
                return NotFound("Justification Of Award does not exist");
            }

            _justificationOfAwardRepository.Delete(justificationofAward);

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Justification of Award",
                Url = "/api/v1/justificationofaward/deletejustificationofaward",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(
                  new
                  {
                      message = "Justification of Award Deleted successfully"
                  });
        }


        // Single Tender Justification 

        // 

        [HttpGet("[action]")]
        public async Task<IActionResult> SingleTenderJustificationForm()
        {
            var userId = GetUserId();

            var projects = await _projectsRepository.GetAllAsync();
            //var quotationMasters = _quotationMasterRepository.GetAll().ToList();
            var suppliers = _supplierIdentificationRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "Single Tender Justification",
                Url = "/api/v1/justificationofaward/singletenderjustificationform",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(new
            {
                Projects = projects,
                //QuotationMasters = quotationMasters,
                Suppliers = suppliers
            });
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSingleTenderJustification([FromForm] SingleTenderJustificationFormModel model)
        {
            var userId = GetUserId();
            var endPointId = await GetEndPointId();

            if (ModelState.IsValid)
            {

                var singleTenderJustification = new TblSingleTenderJustification
                {
                    Address = model.Address,
                    ContactName = model.ContactName,
                    Email = model.Email,
                    TelephoneNumber = model.TelephoneNumber,
                    ProjectId = model.ProjectId,
                    ProposedContract = model.ProposedContract,
                    ProposedContractValue = model.ProposedContractValue,
                    ProposedContractor = model.ProposedContractor,
                    Justification = model.Justification,
                    AdditionalInfo = UploadFile(model.AdditionalInfo),
                    CreatedDate = DateTime.Now,

                };

                await _singleTenderJustificationRepository.CreateAsync(singleTenderJustification);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

                // write logic to create TblAuthList object
                var newAudit = new TblAuthList
                {
                    Title = "Single Tender Justification",
                    Url = "/api/v1/justificationofaward/createsingletenderjustification",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);

                // login for email notification
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                await _auditRepository.SaveChangesAsync();

                return Ok(
                   new
                   {
                       message = "Single Tender Justification created successfully",
                       EmailAddress = emailAddress
                   });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateSingleTenderJustfication([FromForm] SingleTenderJustificationFormModel model, [FromQuery] int singleTenderJustficationId)
        {
            var userId = GetUserId();
            var endPointId = await GetEndPointId();

            if (ModelState.IsValid)
            {
                var singleTenderJustification = await _singleTenderJustificationRepository.GetByIdAsync(singleTenderJustficationId);

                if (singleTenderJustification == null)
                {
                    return NotFound(new { message = "Single Tender Justification does not exist" });
                }


                // assign updated fields

                singleTenderJustification.Address = model.Address;
                singleTenderJustification.ContactName = model.ContactName;
                singleTenderJustification.Email = model.Email;
                singleTenderJustification.TelephoneNumber = model.TelephoneNumber;
                singleTenderJustification.ProjectId = model.ProjectId;
                singleTenderJustification.ProposedContract = model.ProposedContract;
                singleTenderJustification.ProposedContractValue = model.ProposedContractValue;
                singleTenderJustification.ProposedContractor = model.ProposedContractor;
                singleTenderJustification.Justification = model.Justification;
                singleTenderJustification.AdditionalInfo = UploadFile(model.AdditionalInfo);

                _singleTenderJustificationRepository.Update(singleTenderJustification);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                // write logic to create TblAuthList object
                var newAudit = new TblAuthList
                {
                    Title = "Single Tender Justfication",
                    Url = "/api/v1/justficationofaward/updatesingletenderjustification",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);

                // login for email notification
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                await _auditRepository.SaveChangesAsync();

                return Ok(
                   new
                   {
                       message = "Single Tender Justification updated successfully",
                       EmailAddress = emailAddress
                   });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetSingleTenderJustfication([FromQuery] int id)
        {
            var userId = GetUserId();

            var singleTenderJustification = await _singleTenderJustificationRepository.GetByIdAsync(id);
            if (singleTenderJustification == null)
            {
                return NotFound("Single Tender Justfication does not exist");
            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Justfication Of Award",
                Url = "/api/v1/justificationofaward/getsingletenderjustification",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(singleTenderJustification);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSingleTenderJustification()
        {
            var userId = GetUserId();

            var singleTenderJustifications = await _singleTenderJustificationRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Justification Of Award",
                Url = "/api/v1/justificationofaward/getallsingletenderjustification",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);


            return Ok(singleTenderJustifications);

        }


        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSingleTenderJustification([FromQuery] int id)
        {
            var userId = GetUserId();

            var singleTenderJustification = await _singleTenderJustificationRepository.GetByIdAsync(id);
            if (singleTenderJustification == null)
            {
                return NotFound("Single Tender Justification does not exist");
            }

            _singleTenderJustificationRepository.Delete(singleTenderJustification);
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Justification of Award",
                Url = "/api/v1/justificationofaward/deletesingletenderjustification",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            return Ok(
                  new
                  {
                      message = "Single Tender Justification Deleted successfully"
                  });

        }




        // Approval WorkFlow
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCheckerStatus([FromBody] AuthStatusModel model)
        {
            var userId = GetUserId();
            var endPointId = await GetEndPointId();

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Parameters...");
            }
            else
            {
                // email address to initiator
                var emailAddress = await _emailAddressRepository.SendEmailAddress(model.BatchId);
                // if checker status was not selected
                if (model.Status == 0)
                {
                    return BadRequest(new { message = "Status was not selected" });
                }

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                // if checker rejects
                if (model.Status == 3)
                {
                    var audit = new TblAuthList
                    {
                        Title = model.Title,
                        Url = model.Url,
                        CreatedDate = DateTime.Now,
                        Status = model.Status,
                        StaffId = tblStaff.StaffId,
                        BatchId = model.BatchId
                    };

                    await _auditRepository.CreateAsync(audit);

                    var newAuthChecker = new TblAuthChecker
                    {
                        AuthId = audit.AuthId,
                        CreatedDate = DateTime.Now,
                        Status = model.Status,
                        Reason = model.Reason,
                        StaffId = tblStaff.StaffId,
                    };

                    await _authCheckerRepository.CreateAsync(newAuthChecker);
                }
                // if checker approves 
                if (model.Status == 2)
                {


                    var audit = new TblAuthList
                    {
                        Title = model.Title,
                        Url = model.Url,
                        CreatedDate = DateTime.Now,
                        Status = model.Status,
                        StaffId = tblStaff.StaffId,
                        BatchId = model.BatchId
                    };

                    await _auditRepository.CreateAsync(audit);

                    var newAuthChecker = new TblAuthChecker
                    {
                        AuthId = audit.AuthId,
                        CreatedDate = DateTime.Now,
                        Status = model.Status,
                        Reason = model.Reason,
                        StaffId = tblStaff.StaffId,
                    };

                    await _authCheckerRepository.CreateAsync(newAuthChecker);

                    emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 2);
                }
                // if checker reviews
                if (model.Status == 1)
                {
                    var audit = new TblAuthList
                    {
                        Title = model.Title,
                        Url = model.Url,
                        CreatedDate = DateTime.Now,
                        Status = model.Status,
                        StaffId = tblStaff.StaffId,
                        BatchId = model.BatchId
                    };

                    await _auditRepository.CreateAsync(audit);

                    var newAuthChecker = new TblAuthChecker
                    {
                        AuthId = audit.AuthId,
                        CreatedDate = DateTime.Now,
                        Status = model.Status,
                        Reason = model.Reason,
                        StaffId = tblStaff.StaffId,
                    };

                    await _authCheckerRepository.CreateAsync(newAuthChecker);
                    _auditRepository.Update(audit);
                }

                await _auditRepository.SaveChangesAsync();

                return Ok(new { message = "Checker status registered...", EmailAddress = emailAddress, StatusReason = model.Reason });
            }
        }


        // POST: api/v1/
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAuthorizerStatus([FromBody] AuthStatusModel model, string authorizerCode)
        {

            var userId = GetUserId();
            var endPointId = GetEndPointId();

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Parameters...");
            }
            else
            {

                var emailAddress = await _emailAddressRepository.SendEmailAddress(model.BatchId);

                // if authorizerstatus was not selected
                if (model.Status == 0)
                {
                    return BadRequest(new { message = "Status was not selected" });
                }

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

                // if authorizer Rejects 
                if (model.Status == 3)
                {

                    var audit = new TblAuthList
                    {
                        Title = model.Title,
                        Url = model.Url,
                        CreatedDate = DateTime.Now,
                        Status = model.Status,
                        StaffId = tblStaff.StaffId,
                        BatchId = model.BatchId
                    };

                    var newAuthApprover = new TblAuthApprover
                    {
                        AuthId = audit.AuthId,
                        CreatedDate = DateTime.Now,
                        Status = model.Status,
                        Reason = model.Reason,
                        StaffId = tblStaff.StaffId,
                    };

                    await _authApproverRepository.CreateAsync(newAuthApprover);
                }

                // if authorizer approves 
                if (model.Status == 2)
                {

                    var codes = await _codeGeneratorRepository.FirstOrDefaultAsync(x => x.GeneratedCode == authorizerCode);

                    if (codes == null)
                    {
                        return BadRequest(new { message = "Code is invalid" });
                    }

                    if (codes != null)
                    {
                        codes.Status = 1;
                        _codeGeneratorRepository.Update(codes);

                        var audit = new TblAuthList
                        {
                            Title = model.Title,
                            Url = model.Url,
                            CreatedDate = DateTime.Now,
                            Status = model.Status,
                            StaffId = tblStaff.StaffId,
                            BatchId = model.BatchId
                        };

                        var newAuthApprover = new TblAuthApprover
                        {
                            AuthId = audit.AuthId,
                            CreatedDate = DateTime.Now,
                            Status = model.Status,
                            Reason = model.Reason,
                            StaffId = tblStaff.StaffId,
                        };

                        await _authApproverRepository.CreateAsync(newAuthApprover);
                    }
                }

                // if authorizer reviews
                if (model.Status == 1)
                {
                    var audit = new TblAuthList
                    {
                        Title = model.Title,
                        Url = model.Url,
                        CreatedDate = DateTime.Now,
                        Status = model.Status,
                        StaffId = tblStaff.StaffId,
                        BatchId = model.BatchId
                    };

                    var newAuthApprover = new TblAuthApprover
                    {
                        AuthId = audit.AuthId,
                        CreatedDate = DateTime.Now,
                        Status = model.Status,
                        Reason = model.Reason,
                        StaffId = tblStaff.StaffId,
                    };

                    await _authApproverRepository.CreateAsync(newAuthApprover);
                    await _authApproverRepository.SaveChangesAsync();
                }

                return Ok(new { message = "Authorizer status registered...", EmailAddress = emailAddress, StatusReason = model.Reason });
            }
        }
    }
}
