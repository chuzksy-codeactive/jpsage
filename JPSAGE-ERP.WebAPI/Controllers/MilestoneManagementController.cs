using JPSAGE_ERP.Application.Interfaces;
using JPSAGE_ERP.Application.Models.ApprovalWorkFlow;
using JPSAGE_ERP.Application.Models.MIlestoneManagement;
using JPSAGE_ERP.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JPSAGE_ERP.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class MilestoneManagementController : ControllerBase
    {
        private readonly IRepository<TblJobCompletionCertificate> _jobCompletionCertificateRepository;
        private readonly IRepository<TblSupplierIdentification> _supplierRepository;
        private readonly IRepository<TblAuthList> _auditRepository;
        private readonly IRepository<TblAuthChecker> _authCheckerRepository;
        private readonly IRepository<TblAuthApprover> _authApproverRepository;
        private readonly IRepository<TblStaffBioData> _staffRepository;
        private readonly IRepository<TblWorkflowProcessDef> _workFlowRepository;
        private readonly IRepository<TblCodeGenerator> _codeGeneratorRepository;
        private readonly IEmailAddressRepository _emailAddressRepository;

        public MilestoneManagementController(
            IRepository<TblJobCompletionCertificate> jobCompletionCertificateRepository,
            IRepository<TblSupplierIdentification> supplierRepository,
            IRepository<TblAuthList> auditRepository,
            IRepository<TblAuthChecker> authCheckerRepository,
            IRepository<TblAuthApprover> authApproverRepository,
            IRepository<TblStaffBioData> staffRepository,
            IRepository<TblWorkflowProcessDef> workFlowRepository,
            IRepository<TblCodeGenerator> codeGeneratorRepository,
            IEmailAddressRepository emailAddressRepository)
        {
            _jobCompletionCertificateRepository = jobCompletionCertificateRepository;
            _supplierRepository = supplierRepository;
            _auditRepository = auditRepository;
            _authCheckerRepository = authCheckerRepository;
            _authApproverRepository = authApproverRepository;
            _staffRepository = staffRepository;
            _workFlowRepository = workFlowRepository;
            _codeGeneratorRepository = codeGeneratorRepository;
            _emailAddressRepository = emailAddressRepository;
        }

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
        public async Task<int> GetEndPointId()
        {
            var tblWorkflow = await _workFlowRepository.FirstOrDefaultAsync(x => x.WfdefId == 9);
            return tblWorkflow.WfdefId;
        }

        [NonAction]
        public async Task<string> GetAuthorizerCode()
        {
            var codeGenerator = await _codeGeneratorRepository.FirstOrDefaultAsync(x => x.Status == 0);

            return codeGenerator.GeneratedCode;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllJCC()
        {
            //var formlist = new List<MilestoneManagementResponseObject>();
            var userId = GetUserId();

            var mastersList = await _jobCompletionCertificateRepository.GetAllAsync();
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            var newAudit = new TblAuthList
            {
                Title = "MilestoneManagement",
                Url = "/api/v1/milestonemanagement/getallforms",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(mastersList);
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetJCC([FromQuery] int id)
        {
            var userId = GetUserId();

            var jobCompletionCertificate = await _jobCompletionCertificateRepository.GetByIdAsync(id);

            if (jobCompletionCertificate == null)
            {
                return NotFound("Form does not exist");
            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            var newAudit = new TblAuthList
            {
                Title = "MilestoneManagement",
                Url = "/api/v1/milestonemanagement/getjcc",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(jobCompletionCertificate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet("[action]")]
        public async Task<IActionResult> JCCForm()
        {
            var userId = GetUserId();
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            var newAudit = new TblAuthList
            {
                Title = "MilestoneManagement",
                Url = "/api/v1/milestonemanagement/jccform",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(new
            {
                Suppliers = await _supplierRepository.GetAllAsync()
            });
        }

        /// <summary>
        /// This creates the end user requisition 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateJCC([FromBody] JobCompletionCertificateFormModel model)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {
                var form = new TblJobCompletionCertificate
                {
                    CertificateNumber = model.CertificateNumber,
                    WorkOrder = model.WorkOrder,
                    SupplierId = model.SupplierId,
                    Address = model.Address,
                    DeliveryAddress = model.DeliveryAddress,
                    Telephone = model.Telephone,
                    Email = model.Email,
                    RecieptDate = model.RecieptDate,
                    ServiceDescription = model.ServiceDescription,
                    CreatedDate = DateTime.Now
                };

                await _jobCompletionCertificateRepository.CreateAsync(form);


                var endPointId = await GetEndPointId();
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);
                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

                var newAudit = new TblAuthList
                {
                    Title = "MilestoneManagement",
                    Url = "/api/v1/milestonemanagement/createjcc",
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
                        message = "Job completion certificate created successfully",
                        EmailAddress = emailAddress
                    });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateJCC([FromBody] JobCompletionCertificateFormModel model, [FromQuery] int Jccid)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {
                var form = await _jobCompletionCertificateRepository.GetByIdAsync(Jccid);

                if (form == null)
                {
                    return NotFound(new { message = "Certificate does not exist" });
                }

                form.CertificateNumber = model.CertificateNumber;
                form.WorkOrder = model.WorkOrder;
                form.SupplierId = model.SupplierId;
                form.Address = model.Address;
                form.DeliveryAddress = model.DeliveryAddress;
                form.Telephone = model.Telephone;
                form.Email = model.Email;
                form.RecieptDate = model.RecieptDate;
                form.ServiceDescription = model.ServiceDescription;

                _jobCompletionCertificateRepository.Update(form);

                var endPointId = await GetEndPointId();
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);
                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

                var newAudit = new TblAuthList
                {
                    Title = "MilestoneManagement",
                    Url = "/api/v1/milestonemanagement/updatejcc",
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
                        message = "Job completion certificate Updated successfully",
                        EmailAddress = emailAddress
                    });
            }

            return BadRequest(model);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteJCC([FromQuery] int id)
        {
            var userId = GetUserId();

            var jobCompletionCertificate = await _jobCompletionCertificateRepository.GetByIdAsync(id);
            if (jobCompletionCertificate == null)
            {
                return NotFound("Job completion certificate does not exist");
            }

            _jobCompletionCertificateRepository.Delete(jobCompletionCertificate);
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "MilestoneManagement",
                Url = "/api/v1/invoice/deletejcc",
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
                      message = "Job completion certificate Deleted successfully"
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
            var endPointId = await GetEndPointId();
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

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
                }

                await _authApproverRepository.SaveChangesAsync();

                return Ok(new { message = "Authorizer status registered...", EmailAddress = emailAddress, StatusReason = model.Reason });
            }
        }

    }
}
