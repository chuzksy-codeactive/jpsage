using JPSAGE_ERP.Application.Helpers;
using JPSAGE_ERP.Application.Interfaces;
using JPSAGE_ERP.Application.Models.Admin.Client;
using JPSAGE_ERP.Application.Models.Admin.Company;
using JPSAGE_ERP.Application.Models.Admin.Department;
using JPSAGE_ERP.Application.Models.Admin.DocumentType;
using JPSAGE_ERP.Application.Models.Admin.Manufacturers;
using JPSAGE_ERP.Application.Models.Admin.PaymentBank;
using JPSAGE_ERP.Application.Models.Admin.Position;
using JPSAGE_ERP.Application.Models.Admin.Project;
using JPSAGE_ERP.Application.Models.Admin.StaffForm;
using JPSAGE_ERP.Application.Models.Admin.WorkFlowProcessDefinition;
using JPSAGE_ERP.Application.Models.ApprovalWorkFlow;
using JPSAGE_ERP.Application.Services;
using JPSAGE_ERP.DataObjects.Admin.Department;
using JPSAGE_ERP.DataObjects.Admin.ListObjects;
using JPSAGE_ERP.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JPSAGE_ERP.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize("RequireAdministratorRole")]
    [ProducesResponseType(401)]
    public class AdminModuleController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<TblClients> _clientRepository;
        private readonly IRepository<TblCompanyInfo> _companyInfoRepository;
        private readonly IRepository<TblAuthList> _auditRepository;
        private readonly IEmailAddressRepository _emailAddressRepository;
        private readonly IRepository<TblManufacturers> _manufacturersRepository;
        private readonly IRepository<TblAuthChecker> _authCheckerRepository;
        private readonly IRepository<TblAuthApprover> _authApproverRepository;
        private readonly IRepository<TblProjects> _projectsRepository;
        private readonly IRepository<TblStaffBioData> _staffRepository;
        private readonly IRepository<TblDepartments> _departmentRepository;
        private readonly IRepository<TblPosition> _positionRepository;
        private readonly IRepository<TblPaymentBank> _paymentBankRepository;
        private readonly IRepository<TblWorkflowProcessDef> _workFlowRepository;
        private readonly IRepository<TblStaffRoles> _staffRoleRepository;
        private readonly IRepository<TblCodeGenerator> _codeGeneratorRepository;
        private readonly IRepository<TblDocumentType> _documentTypeRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AdminModuleController(UserManager<ApplicationUser> userManager,
            IRepository<TblClients> clientRepository,
            IRepository<TblCompanyInfo> companyInfoRepository,
            IRepository<TblAuthList> auditRepository,
            IEmailAddressRepository emailAddressRepository,
            IRepository<TblManufacturers> manufacturersRepository,
            IRepository<TblAuthChecker> authCheckerRepository,
            IRepository<TblAuthApprover> authApproverRepository,
            IRepository<TblProjects> projectsRepository,
            IRepository<TblStaffBioData> staffRepository,
            IRepository<TblDepartments> departmentRepository,
            IRepository<TblPosition> positionRepository,
            IRepository<TblPaymentBank> paymentBankRepository,
            IRepository<TblWorkflowProcessDef> workFlowRepository,
            IRepository<TblStaffRoles> staffRoleRepository,
            IRepository<TblCodeGenerator> codeGeneratorRepository,
            IRepository<TblDocumentType> documentTypeRepository,
            IWebHostEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _clientRepository = clientRepository;
            _companyInfoRepository = companyInfoRepository;
            _auditRepository = auditRepository;
            _emailAddressRepository = emailAddressRepository;
            _manufacturersRepository = manufacturersRepository;
            _authCheckerRepository = authCheckerRepository;
            _authApproverRepository = authApproverRepository;
            _projectsRepository = projectsRepository;
            _staffRepository = staffRepository;
            _departmentRepository = departmentRepository;
            _positionRepository = positionRepository;
            _paymentBankRepository = paymentBankRepository;
            _workFlowRepository = workFlowRepository;
            _staffRoleRepository = staffRoleRepository;
            _codeGeneratorRepository = codeGeneratorRepository;
            _documentTypeRepository = documentTypeRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        // generally used methods
        #region Helpers

        /// <summary>
        /// This helper method gets the current signed in user Id
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public string GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.Claims.Skip(1).FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);


            var userId = claim.Value;
            return userId;
        }


        /// <summary>
        /// This helper method gets the Id of this current workflow in the work flow process definition table
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public async Task<int> GetEndPointId()
        {
            var tblWorkflow = await _workFlowRepository.FirstOrDefaultAsync(x => x.WfdefId == 1);
            return tblWorkflow.WfdefId;
        }


        /// <summary>
        /// This helper method is used to get authorization code from the database
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public async Task<IActionResult> SendAuthorizerCode()
        {
            var tblWorkflow = await _workFlowRepository.FirstOrDefaultAsync(x => x.WfdefId == 1);
            var tblCodeGenerator = await _codeGeneratorRepository.FirstOrDefaultAsync(x => x.Status == 0);

            if (tblCodeGenerator.GeneratedCode == null)
            {
                return NoContent();
            }

            var emailAddress = await _emailAddressRepository.SendEmailAddress(tblWorkflow.WfdefId, 1);

            return Ok(new
            {
                EmailAddress = emailAddress,
                tblCodeGenerator.GeneratedCode
            });
        }



        /// <summary>
        /// This helper method is used to upload documents in the file upload directory of the application
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This endpoint is used to create a client 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateClient([FromForm] CreateClientFormModel model)
        {
            var userId = GetUserId();
            var endPointId = await GetEndPointId();

            if (ModelState.IsValid)
            {

                var client = new TblClients
                {
                    ClientName = model.ClientName,
                    Description = model.Description,
                    CreatedDate = DateTime.Now,
                };

                using (var memoryStream = new MemoryStream())
                {
                    await model.ClientLogo.CopyToAsync(memoryStream);

                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 2097152)
                    {

                        client.ClientLogo = memoryStream.ToArray();

                    }
                    else
                    {
                        //ModelState.AddModelError("File", "The file is too large.");

                        return BadRequest(new { message = "The file is too large, must be less than 2MB" });
                    }
                }

                await _clientRepository.CreateAsync(client);


                // write logic to create TblAuthList object

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "Create Client",
                    Url = "/api/v1/adminmodule/createclient",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);

                // login for email notification

                //int endPointId = _workFlowRepository.Find(x => x.WFDefId == 1).FirstOrDefault().WFDefId;
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                await _auditRepository.SaveChangesAsync();

                return Ok(
                   new
                   {
                       message = "Client created successfully",
                       EmailAddress = emailAddress
                   });
            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });

        }





        /// <summary>
        /// This endpoint updates the client profile
        /// </summary>
        /// <param name="model"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateClient([FromForm] UpdateClientFormModel model, [FromQuery] int clientId)
        {
            var userId = GetUserId();
            var endPointId = await GetEndPointId();

            if (ModelState.IsValid)
            {
                var client = await _clientRepository.GetByIdAsync(clientId);

                if (client == null)
                {
                    return NotFound(new { message = "Client does not exist" });
                }

                // validating upload size
                using (var memoryStream = new MemoryStream())
                {
                    await model.ClientLogo.CopyToAsync(memoryStream);

                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 2097152)
                    {
                        client.ClientLogo = memoryStream.ToArray();
                    }
                    else
                    {
                        //ModelState.AddModelError("File", "The file is too large.");

                        return BadRequest(new { message = "The file is too large, must be less than 2MB" });
                    }
                }

                // assign updated fields
                client.ClientName = model.ClientName;
                client.Description = model.Description;




                _clientRepository.Update(client);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                // write logic to create TblAuthList object
                var newAudit = new TblAuthList
                {
                    Title = "Update Client",
                    Url = "/api/v1/adminmodule/updateclient",
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
                       message = "Client updated successfully",
                       EmailAddress = emailAddress
                   });


            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });

        }




        /// <summary>
        /// Thiis endpoint gets a client's data with a specified Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(TblClients), 404)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetClient([FromQuery] int id)
        {
            var userId = GetUserId();

            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound("Client does not exist");
            }


            // write logic to create TblAuthList object
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "Get Client",
                Url = "/api/v1/adminmodule/getclient",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(client);
        }




        /// <summary>
        /// This endpoint gets all the client info from the database
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<TblClients>), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllClients()
        {
            var userId = GetUserId();

            var clients = await _clientRepository.GetAllAsync();

            //if (clients == null)
            //{
            //    return NotFound("Client does not exist");
            //}

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Get All Clients",
                Url = "/api/v1/adminmodule/getallclients",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(clients);
        }




        /// <summary>
        /// This method deletes a client from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteClient([FromQuery] int id)
        {
            var userId = GetUserId();

            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound("Client does not exist");
            }

            _clientRepository.Delete(client);
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Delete Client",
                Url = "/api/v1/adminmodule/deleteclient",
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
                      message = "Client Deleted successfully"
                  });
        }






        //Company Profile



        /// <summary>
        /// This endpoint creates a company
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCompany([FromForm] CreateCompanyFormModel model)
        {
            var userId = GetUserId();
            var endPointId = await GetEndPointId();

            if (ModelState.IsValid)
            {
                var company = new TblCompanyInfo
                {
                    CompanyName = model.CompanyName,
                    Address = model.Address,
                    PhoneNumber1 = model.PhoneNumber1,
                    PhoneNumber2 = model.PhoneNumber2,
                    EmailAddress = model.EmailAddress,
                    WebsiteUrl = model.WebsiteUrl,
                    CreatedDate = DateTime.Now,

                };

                using (var memoryStream = new MemoryStream())
                {
                    await model.CompanyLogo.CopyToAsync(memoryStream);

                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 2097152)
                    {

                        company.CompanyLogo = memoryStream.ToArray();


                    }
                    else
                    {
                        return BadRequest(new { message = "The file is too large, must be less than 2MB" });
                    }
                }


                await _companyInfoRepository.CreateAsync(company);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "Create Company",
                    Url = "/api/v1/adminmodule/createcompany",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);



                // login for email notification
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                // write logic to create TblAuthList object

                await _auditRepository.SaveChangesAsync();

                return Ok(
                   new
                   {
                       message = "Company created successfully",
                       EmailAddress = emailAddress
                   });
            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });

        }




        /// <summary>
        /// This endpoint updates a company 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCompany([FromForm] UpdateCompanyFormModel model, [FromQuery] int companyId)
        {

            var userId = GetUserId();
            var endPointId = await GetEndPointId();

            if (ModelState.IsValid)
            {
                var company = await _companyInfoRepository.GetByIdAsync(companyId);

                if (company == null)
                {
                    return NotFound(new { message = "Company does not exist" });
                }

                using (var memoryStream = new MemoryStream())
                {
                    await model.CompanyLogo.CopyToAsync(memoryStream);

                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 2097152)
                    {

                        company.CompanyLogo = memoryStream.ToArray();


                    }
                    else
                    {
                        return BadRequest(new { message = "The file is too large, must be less than 2MB" });
                    }
                }

                company.Address = model.Address;
                company.CompanyName = model.CompanyName;
                company.EmailAddress = model.EmailAddress;
                company.PhoneNumber1 = model.PhoneNumber1;
                company.PhoneNumber2 = model.PhoneNumber2;
                company.WebsiteUrl = model.WebsiteUrl;


                _companyInfoRepository.Update(company);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "Update Company",
                    Url = "/api/v1/adminmodule/updatecompany",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);

                // login for email notification
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                await _auditRepository.SaveChangesAsync();

                // write logic to create TblAuthList object

                return Ok(
                   new
                   {
                       message = "Company updated successfully",
                       EmailAddress = emailAddress
                   });
            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });

        }


        /// <summary>
        /// This endpoint gets a particular company whose Id is specified
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(TblCompanyInfo), 404)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCompany([FromQuery] int id)
        {

            var userId = GetUserId();

            var company = await _companyInfoRepository.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound("Company does not exist");
            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "Get Company",
                Url = "/api/v1/adminmodule/getcompany",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            // write logic to create TblAuthList object
            return Ok(company);

        }



        /// <summary>
        /// This particular endpoint gets all companies registered in the database
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<TblCompanyInfo>), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var userId = GetUserId();

            var companies = await _companyInfoRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Get All Companies",
                Url = "/api/v1/adminmodule/getallcompanies",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(companies);
        }



        /// <summary>
        /// This particular endpoint deletes a registered company of a particular Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCompany([FromQuery] int id)
        {
            var userId = GetUserId();

            var company = await _companyInfoRepository.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound("Company does not exist");
            }

            _companyInfoRepository.Delete(company);

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Delete Company",
                Url = "/api/v1/adminmodule/deletecompany",
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
                      message = "Company Deleted successfully"
                  });
        }




        // Departments


        /// <summary>
        /// This particular endpoint is To get all list objects needed for selection in creating or updating a department
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> DepartmentForm()
        {
            var userId = GetUserId();

            var Statuses = new List<StatusListObject>
            {
                new StatusListObject {Text = "Active", Value = 0},
                new StatusListObject {Text = "Inactive", Value = 1}
            };

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "Department",
                Url = "/api/v1/adminmodule/departmentform",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(new { Statuses });
        }



        /// <summary>
        /// This endpoint handles creating of a department
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentFormModel model)
        {
            var userId = GetUserId();
            var endPointId = await GetEndPointId();

            if (ModelState.IsValid)
            {

                var department = new TblDepartments
                {
                    DepartmentName = model.DepartmentName,
                    DepartmentCode = model.DepartmentCode,
                    Status = model.Status,
                    CreatedDate = DateTime.Now,

                };

                await _departmentRepository.CreateAsync(department);


                // write logic to create TblAuthList object
                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "Department",
                    Url = "/api/v1/adminmodule/createdepartment",
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
                       message = "Department created successfully",
                       EmailAddress = emailAddress
                   });
            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });

        }




        /// <summary>
        /// This endpoint handles the Update of a department with a specified Id in the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentFormModel model, [FromQuery] int departmentId)
        {
            var userId = GetUserId();
            var endPointId = await GetEndPointId();

            if (ModelState.IsValid)
            {
                var department = await _departmentRepository.GetByIdAsync(departmentId);

                if (department == null)
                {
                    return NotFound(new { message = "Department does not exist" });
                }


                // assign updated fields
                department.DepartmentName = model.DepartmentName;
                department.DepartmentCode = model.DepartmentCode;


                _departmentRepository.Update(department);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                // write logic to create TblAuthList object
                var newAudit = new TblAuthList
                {
                    Title = "Department",
                    Url = "/api/v1/adminmodule/updatedepartment",
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
                       message = "Department updated successfully",
                       EmailAddress = emailAddress
                   });
            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });

        }


        /// <summary>
        /// This endpoint gets a department with a specified Id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(TblDepartments), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetDepartment([FromQuery] int id)
        {
            var userId = GetUserId();

            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound("Department does not exist");
            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object

            var newAudit = new TblAuthList
            {
                Title = "Department",
                Url = "/api/v1/adminmodule/getdepartment",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(department);

        }



        /// <summary>
        /// This endpoint gets all departments in the database
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<TblDepartments>), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var userId = GetUserId();

            var departments = await _departmentRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Department",
                Url = "/api/v1/adminmodule/getalldepartments",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(departments);
        }




        /// <summary>
        /// This endpoint deletes a department with a specified Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteDepartment([FromQuery] int id)
        {
            var userId = GetUserId();

            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound("Department does not exist");
            }

            _departmentRepository.Delete(department);

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Department",
                Url = "/api/v1/adminmodule/deletedepartment",
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
                      message = "Department Deleted successfully"
                  });
        }







        // Position

        /// <summary>
        /// This endpoint gets List of dropdown objects required in selection for creating or updating a position
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> PositionForm()
        {
            var userId = GetUserId();

            var Statuses = new List<StatusListObject>
            {
                new StatusListObject {Text = "Active", Value = 0},
                new StatusListObject {Text = "Inactive", Value = 1}
            };

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "Position",
                Url = "/api/v1/adminmodule/positionform",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(new { Statuses });
        }



        /// <summary>
        /// This endpoint handles creating a position in the application
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePosition([FromBody] CreatePositionFormModel model)
        {
            var userId = GetUserId();
            var endPointId = await GetEndPointId();
            var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

            if (ModelState.IsValid)
            {

                var position = new TblPosition
                {
                    PositionTitle = model.PositionTitle,
                    PositionCode = model.PositionCode,
                    Status = model.Status,
                    CreatedDate = DateTime.Now,
                };


                await _positionRepository.CreateAsync(position);


                // write logic to create TblAuthList object

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "Position",
                    Url = "/api/v1/adminmodule/createposition",
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
                       message = "Position created successfully",
                       EmailAddress = emailAddress
                   });
            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });

        }




        /// <summary>
        /// This endpoint updates a position of a specified Id in the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="positionId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePosition([FromBody] UpdatePositionFormModel model, [FromQuery] int positionId)
        {
            var userId = GetUserId();
            var endPointId = await GetEndPointId();
            var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

            if (ModelState.IsValid)
            {
                var position = await _positionRepository.GetByIdAsync(positionId);

                if (position == null)
                {
                    return NotFound(new { message = "Position does not exist" });
                }


                // assign updated fields
                position.PositionTitle = model.PositionTitle;
                position.PositionCode = model.PositionCode;

                _positionRepository.Update(position);
                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

                // write logic to create TblAuthList object
                var newAudit = new TblAuthList
                {
                    Title = "Position",
                    Url = "/api/v1/adminmodule/updateposition",
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
                       message = "Position updated successfully",
                       EmailAddress = emailAddress
                   });
            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });

        }



        /// <summary>
        /// This endpoint gets a position of a specified Id in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(TblPosition), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPosition([FromQuery] int id)
        {
            var userId = GetUserId();

            var position = await _positionRepository.GetByIdAsync(id);
            if (position == null)
            {
                return NotFound("Position does not exist");
            }


            // write logic to create TblAuthList object
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "Position",
                Url = "/api/v1/adminmodule/getposition",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(position);
        }



        /// <summary>
        /// This endpoint gets a List of all the Positions in the database
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<TblPosition>), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPositions()
        {
            var userId = GetUserId();

            var positions = await _positionRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Position",
                Url = "/api/v1/adminmodule/getallpositions",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(positions);
        }



        /// <summary>
        /// This endpoint deletes a position of a specified Id in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePosition([FromQuery] int id)
        {
            var userId = GetUserId();

            var position = await _positionRepository.GetByIdAsync(id);
            if (position == null)
            {
                return NotFound("Position does not exist");
            }

            _positionRepository.Delete(position);

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Position",
                Url = "/api/v1/adminmodule/deleteposition",
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
                      message = "Position Deleted successfully"
                  });
        }







        //Manufacturers


        /// <summary>
        /// This endpoint gets list of dropdown objects required to be selected for creating a Manufacturer
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> ManufacturersForm()
        {
            var userId = GetUserId();

            var Statuses = new List<StatusListObject>
            {
                new StatusListObject {Text = "Processing Request", Value = 0},
                new StatusListObject {Text = "Request has been processed", Value = 1}
            };

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "Position",
                Url = "/api/v1/adminmodule/manufacturersform",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(new { Statuses });
        }



        /// <summary>
        /// This endpoint handles the creation of a new Manufacturer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateManufacturer([FromBody] CreateManufacturerFormModel model)
        {

            var userId = GetUserId();
            var endPointId = await GetEndPointId();

            if (ModelState.IsValid)
            {
                var manufacturer = new TblManufacturers
                {
                    ManufacturerName = model.ManufacturerName,
                    Description = model.Description,
                    CreatedDate = DateTime.Now,

                    //FinalApprovalDate = null

                };

                await _manufacturersRepository.CreateAsync(manufacturer);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "Manufacturer",
                    Url = "/api/v1/adminmodule/createmanufacturer",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);

                await _auditRepository.SaveChangesAsync();

                // login for email notification
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);
                return Ok(
                   new
                   {
                       message = "Manufacturer created successfully",
                       EmailAddress = emailAddress
                   });


            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });

        }




        /// <summary>
        /// This endpoint handles the update of an existing manufacturer
        /// </summary>
        /// <param name="model"></param>
        /// <param name="manufacturerId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateManufacturer([FromBody] UpdateManufacturerFormModel model, [FromQuery] int manufacturerId)
        {

            var userId = GetUserId();

            if (ModelState.IsValid)
            {
                var manufacturer = await _manufacturersRepository.GetByIdAsync(manufacturerId);
                if (manufacturer == null)
                {
                    return NotFound(new { message = "Manufacturer does not exist" });
                }

                manufacturer.ManufacturerName = model.ManufacturerName;
                manufacturer.Description = model.Description;


                _manufacturersRepository.Update(manufacturer);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "Manufacturer",
                    Url = "/api/v1/adminmodule/updatemanufacturer",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);


                // login for email notification
                var endPointId = await GetEndPointId();
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                await _auditRepository.SaveChangesAsync();
                return Ok(
                   new
                   {
                       message = "Manufacturer updated successfully",
                       EmailAddress = emailAddress
                   });
            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }



        /// <summary>
        /// This endpoint gets a particular existing manufacturer in the database with a specified Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(TblManufacturers), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetManufacturer([FromQuery] int id)
        {
            var userId = GetUserId();

            var manufacturer = await _manufacturersRepository.GetByIdAsync(id);
            if (manufacturer == null)
            {
                return NotFound("Manufacturer does not exist");
            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "Manufacturer",
                Url = "/api/v1/adminmodule/getmanufacturer",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(manufacturer);
        }



        /// <summary>
        /// This endpoint gets all manufacturers existing in the database and returns them as a list
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<TblManufacturers>), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllManufacturers()
        {
            var userId = GetUserId();

            var manufacturers = await _manufacturersRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "Manufacturer",
                Url = "/api/v1/adminmodule/getallmanufacturers",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(manufacturers);

        }



        /// <summary>
        /// This endpoint is used to delete an existing manufacturer with a specified Id in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteManufacturer([FromQuery] int id)
        {
            var userId = GetUserId();

            var manufacturer = await _manufacturersRepository.GetByIdAsync(id);
            if (manufacturer == null)
            {
                return NotFound("Manufacturer does not exist");
            }

            _manufacturersRepository.Delete(manufacturer);

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "Manufacturer",
                Url = "/api/v1/adminmodule/deletemanufacturer",
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
                      message = "Manufacturer Deleted successfully"
                  });

        }








        //Projects


        /// <summary>
        /// This endpoint gets list of dropdown objects to be selected for the creation and update of Projects
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> ProjectForm()
        {
            var userId = GetUserId();


            var ProjectNameList = new[] { "SSGP", "SAPCOM", "OWTF", "OBODO" };
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            var newAudit = new TblAuthList
            {
                Title = "Position",
                Url = "/api/v1/adminmodule/projectform",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(ProjectNameList);
        }




        /// <summary>
        /// This endpoint is used to create a new Project in the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectFormModel model)
        {
            var userId = GetUserId();


            if (ModelState.IsValid)
            {
                var project = new TblProjects
                {
                    ProjectName = model.ProjectName,
                    Description = model.Description,
                    CreatedDate = DateTime.Now,

                };

                await _projectsRepository.CreateAsync(project);


                // write logic to create TblAuthList object

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "Project",
                    Url = "/api/v1/adminmodule/createproject",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);

                // login for email notification
                var endPointId = await GetEndPointId();
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                await _auditRepository.SaveChangesAsync();

                return Ok(
                   new
                   {
                       message = "Project created successfully",
                       EmailAddress = emailAddress
                   });
            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });

        }




        /// <summary>
        /// This endpoint is used to update an existing project with a specified Id in the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectFormModel model, [FromQuery] int projectId)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {
                var project = await _projectsRepository.GetByIdAsync(projectId);

                if (project == null)
                {
                    return NotFound(new { message = "Project does not exist" });
                }

                project.ProjectName = model.ProjectName;
                project.Description = model.Description;

                _projectsRepository.Update(project);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                // write logic to create TblAuthList object
                var newAudit = new TblAuthList
                {
                    Title = "Project",
                    Url = "/api/v1/adminmodule/updateproject",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);


                // login for email notification
                var endPointId = await GetEndPointId();
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                await _auditRepository.SaveChangesAsync();

                return Ok(
                   new
                   {
                       message = "Project updated successfully",
                       EmailAddress = emailAddress
                   });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }





        /// <summary>
        /// This endpoint gets an existing project with a specified Id in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(TblProjects), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProject([FromQuery] int id)
        {
            var userId = GetUserId();

            var project = await _projectsRepository.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound("Project does not exist");
            }

            // write logic to create TblAuthList object
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "Project",
                Url = "/api/v1/adminmodule/getproject",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(project);
        }




        /// <summary>
        /// This endpoint is used to get all existing projects in the database 
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<TblProjects>), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProjects()
        {
            var userId = GetUserId();

            var projects = await _projectsRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "Project",
                Url = "/api/v1/adminmodule/getallprojects",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(projects);
        }




        /// <summary>
        /// This endpoint is used to delete an existing project with a specified Id in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteProject([FromQuery] int id)
        {

            var userId = GetUserId();

            var project = await _projectsRepository.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound("Project does not exist");
            }

            _projectsRepository.Delete(project);

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Project",
                Url = "/api/v1/adminmodule/deleteproject",
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
                      message = "Project Deleted successfully"
                  });
        }

        // Staff biodata

        /// <summary>
        /// This endpoint is used to create a new staff in the database. 
        /// </summary>
        /// <param name="RegData"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost("[action]")]
        public async Task<IActionResult> RegisterStaff([FromForm] CreateStaffFormModel RegData)
        {
            // Will hold all errors related to registration 
            List<string> errorList = new List<string>();

            // server side validation for User object
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = RegData.PersonalEmailAddress,
                    UserName = RegData.PersonalEmailAddress,
                    FirstName = RegData.FirstName,
                    LastName = RegData.LastName,
                    PhoneNumber = RegData.TelephoneNumber,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                // create identity user in the database 
                var result = await _userManager.CreateAsync(user, RegData.Password);

                // tasks to do if user was created successfully
                if (result.Succeeded)
                {
                    // adding default identity user role to created user
                    await _userManager.AddToRoleAsync(user, "Staff");

                    // create Staff bio data
                    var newStaff = new TblStaffBioData
                    {
                        AspnetUserId = user.Id,
                        StaffNumber = RegData.StaffNumber,
                        PersonalEmailAddress = RegData.PersonalEmailAddress,
                        OfficeEmailAddress = RegData.OfficeEmailAddress,
                        FirstName = RegData.FirstName,
                        LastName = RegData.LastName,
                        OfficePhoneNumber = RegData.OfficePhoneNumber,
                        Address = RegData.Address,
                        CityId = RegData.CityId,
                        StateId = RegData.StateId,
                        CountryId = RegData.CountryId,
                        CreatedDate = DateTime.Now,
                        DepartmentId = RegData.DepartmentId,
                        Gender = RegData.Gender,
                        OtherName = RegData.OtherName,
                        PositionId = RegData.PositionId,
                        ProfileImage = UploadFile(RegData.ProfileImage)
                    };

                    await _staffRepository.CreateAsync(newStaff);

                    await _staffRepository.SaveChangesAsync();

                    // Sending Confirmation Email

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { UserId = user.Id, Code = code }, protocol: HttpContext.Request.Scheme);

                    //await _emailSender.SendEmailAsync(user.Email, "JPSAGE.com - Confirm Your Email", "Please confirm your e-mail by clicking this link: <a href=\"" + callbackUrl + "\">click here</a>");

                    // return success message
                    return Ok(new { username = user.UserName, email = user.Email, status = 1, message = "Registration Successful. Staff created successfully" });
                }
                // tasks to do if user was not created successfully
                else
                {
                    // looping throught process errors and adding them to error list object
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        errorList.Add(error.Description);
                    }
                }
            }

            // return bad request response if process fails
            return BadRequest(new JsonResult(errorList));
        }




        /// <summary>
        /// This endpoint is used to update an existing staff with a specified Id in the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="staffId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateStaff([FromForm] UpdateStaffFormModel model, [FromQuery] int staffId)
        {

            var userId = GetUserId();

            if (ModelState.IsValid)
            {
                var staff = await _staffRepository.GetByIdAsync(staffId);

                if (staff == null)
                {
                    return NotFound(new { message = "Staff does not exist" });
                }

                staff.StaffNumber = model.StaffNumber;
                staff.FirstName = model.FirstName;
                staff.LastName = model.LastName;
                staff.OtherName = model.OtherName;
                staff.Gender = model.Gender;
                staff.Address = model.Address;
                staff.CityId = model.CityId;
                staff.CountryId = model.CountryId;
                staff.CountryId = model.CountryId;
                staff.TelephoneNumber = model.TelephoneNumber;
                staff.OfficePhoneNumber = model.OfficePhoneNumber;
                staff.PersonalEmailAddress = model.PersonalEmailAddress;
                staff.ProfileImage = UploadFile(model.ProfileImage);

                _staffRepository.Update(staff);

                var user = await _userManager.FindByIdAsync(staff.AspnetUserId);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.OtherName = model.OtherName;
                user.AddressLine1 = model.Address;
                user.CityId = model.CityId;
                user.CountryId = model.CountryId.GetValueOrDefault();
                user.CountryId = model.CountryId.GetValueOrDefault();
                user.PhoneNumber = model.TelephoneNumber;

                await _userManager.UpdateAsync(user);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                // write logic to create TblAuthList object
                var newAudit = new TblAuthList
                {
                    Title = "StaffBioData",
                    Url = "/api/v1/adminmodule/updatestaff",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);


                // login for email notification
                var endPointId = await GetEndPointId();
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                await _auditRepository.SaveChangesAsync();

                return Ok(
                   new
                   {
                       message = "Staff updated successfully",
                       EmailAddress = emailAddress
                   });
            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });

        }



        /// <summary>
        /// This endpoint is used to get an existing staff with a specific Id in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetStaff([FromQuery] int id)
        {
            var userId = GetUserId();

            var staff = await _staffRepository.GetByIdAsync(id);
            if (staff == null)
            {
                return NotFound("Staff does not exist");
            }

            // write logic to create TblAuthList object
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "StaffBioData",
                Url = "/api/v1/adminmodule/getstaff",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(staff);
        }

        /// <summary>
        /// This endpoint gets all the staff in the database and returns the list as a response
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllStaff()
        {
            var userId = GetUserId();

            var staff = await _staffRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "StaffBioData",
                Url = "/api/v1/adminmodule/getallstaff",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(staff);
        }


        // WorkFlow process Definition


        /// <summary>
        /// This endpoint gets an existing  work flow process definition with a specified Id in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(TblWorkflowProcessDef), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetWorkFlowProcessDefinition([FromQuery] int id)
        {
            var userId = GetUserId();

            var workFlow = _workFlowRepository.GetByIdAsync(id);
            if (workFlow == null)
            {
                return NotFound("Work Flow Does not exist");

            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "WorkFlowProcess",
                Url = "/api/v1/adminmodule/getworkflowprocessdefinition",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(workFlow);
        }


        /// <summary>
        /// This endpoint gets all work flow process definition in the database and returns it as a list
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<TblWorkflowProcessDef>), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllWorkFlowProcessDefinition()
        {
            var userId = GetUserId();

            var workFlowList = await _workFlowRepository.GetAllAsync();
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            var newAudit = new TblAuthList
            {
                Title = "WorkFlowProcess",
                Url = "/api/v1/adminmodule/getallworkflowprocessdefinition",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(workFlowList);
        }

        /// <summary>
        /// This endpoint handles the creation of a work flow process definition in the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateWorkflowProcessDefinition([FromBody] WorkFlowFormModel model)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {
                var newWorkFlow = new TblWorkflowProcessDef
                {
                    Code = model.Code,
                    Description = model.Description,
                    CreatedDate = DateTime.Now
                };

                await _workFlowRepository.CreateAsync(newWorkFlow);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "WorkFlowProcess",
                    Url = "/api/v1/adminmodule/createworkflowprocessdefinition",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);

                await _auditRepository.SaveChangesAsync();

                return Ok(new { message = "Work Flow Created sucessfully" });

            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }



        /// <summary>
        /// This endpoint handles the update of an existing work flow process definition with a specified Id in the database
        /// </summary>
        /// <param name="workFlowId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateWorkflowProcessDefinition([FromQuery] int workFlowId, [FromBody] WorkFlowFormModel model)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {
                var workFlow = await _workFlowRepository.GetByIdAsync(workFlowId);
                if (workFlow == null)
                {
                    return NotFound(new { message = "Work Flow does not exist" });
                }

                workFlow.Code = model.Code;
                workFlow.Description = model.Description;

                _workFlowRepository.Update(workFlow);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "WorkFlowProcess",
                    Url = "/api/v1/adminmodule/updateworkflowprocessdefinition",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);

                await _auditRepository.SaveChangesAsync();

                return Ok(new { message = "Work Flow Process definition updated sucessfully" });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }



        /// <summary>
        /// This endpoint gets the list of dropdown object to be selected for the creation of a staff role and returns it as a list
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> StaffRoleForm()
        {
            var userId = GetUserId();

            var workFlowList = await _workFlowRepository.GetAllAsync();
            var staffList = await _staffRepository.GetAllAsync();
            var aspNetStaffUserList = new List<UserRoleResponseObject>();

            foreach (var staff in staffList)
            {
                var applicationUser = await _userManager.FindByIdAsync(staff.AspnetUserId);
                var userRoles = await _userManager.GetRolesAsync(applicationUser);

                var response = new UserRoleResponseObject
                {
                    Staff = staff,
                    Roles = userRoles
                };

                aspNetStaffUserList.Add(response);
            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "WorkFlowProcess",
                Url = "/api/v1/adminmodule/staffformrole",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(new
            {
                WorkFlowList = workFlowList,
                StaffList = aspNetStaffUserList,

            });
        }



        /// <summary>
        /// This endpoint is used in creating a new work flow checker staff role
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateWorkFlowCheckerStaffRole([FromBody] CreateStaffRoleFormModel model)
        {
            var userId = GetUserId();
            var tblStaffAddress = await _staffRepository.FirstOrDefaultAsync(x => x.StaffId == model.StaffId);
            if (ModelState.IsValid)
            {
                var staffRole = new TblStaffRoles
                {
                    WfdefId = model.WFDefId,
                    StaffId = model.StaffId,
                    Checker = tblStaffAddress.OfficeEmailAddress,
                    CreatedDate = DateTime.Now
                };

                await _staffRoleRepository.CreateAsync(staffRole);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "WorkFlowProcess",
                    Url = "/api/v1/adminmodule/createworkflowcheckerstaffrole",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);

                await _auditRepository.SaveChangesAsync();

                return Ok(new { message = "Work Flow Staff Checker Created sucessfully" });

            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }




        /// <summary>
        /// This endpoint is used in creating a new work flow authorizer role
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateWorkFlowAuthorizerStaffRole([FromBody] CreateStaffRoleFormModel model)
        {
            var userId = GetUserId();
            var tblStaffAddress = await _staffRepository.FirstOrDefaultAsync(x => x.StaffId == model.StaffId);

            if (ModelState.IsValid)
            {
                var staffRole = new TblStaffRoles
                {
                    WfdefId = model.WFDefId,
                    StaffId = model.StaffId,
                    Authorizer = tblStaffAddress.OfficeEmailAddress,
                    CreatedDate = DateTime.Now
                };

                await _staffRoleRepository.CreateAsync(staffRole);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "WorkFlowProcess",
                    Url = "/api/v1/adminmodule/createworkflowauthorizerstaffrole",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);
                await _auditRepository.SaveChangesAsync();

                return Ok(new { message = "Work Flow Staff Authorizer Created sucessfully" });
            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }



        /// <summary>
        /// This endpoint is used to get an existing work flow staff role with a specified Id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(TblStaffRoles), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetWorkFlowStaffRole([FromQuery] int id)
        {
            var userId = GetUserId();

            var staffRole = _staffRoleRepository.GetByIdAsync(id);
            if (staffRole == null)
            {
                return NotFound(new { message = "Staff Role does not exist" });
            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "WorkFlowProcess",
                Url = "/api/v1/adminmodule/getworkflowstaffrole",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(staffRole);

        }




        /// <summary>
        /// This endpoint gets all work flow staff roles from the database 
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<TblStaffRoles>), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetWAllorkFlowStaffRoles()
        {
            var userId = GetUserId();

            var staffRoles = _staffRoleRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "WorkFlowProcess",
                Url = "/api/v1/adminmodule/getallworkflowstaffroles",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(staffRoles);

        }



        /// <summary>
        /// This endpoint is used to delete an existing staff role with a specified Id in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteStaffRole([FromQuery] int id)
        {

            var userId = GetUserId();

            var staffRole = await _staffRoleRepository.GetByIdAsync(id);
            if (staffRole == null)
            {
                return NotFound("Staff does not exist");
            }

            _staffRoleRepository.Delete(staffRole);
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "WorkFlowProcess",
                Url = "/api/v1/adminmodule/deletestaffrole",
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
                      message = "Staff Role Deleted successfully"
                  });
        }




        /// <summary>
        /// This endpoint is used to delete an existing staff with a specified Id in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteStaff([FromQuery] int id)
        {

            var userId = GetUserId();

            var staff = await _staffRepository.GetByIdAsync(id);
            if (staff == null)
            {
                return NotFound("Staff does not exist");
            }

            _staffRepository.Delete(staff);

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "StaffBioData",
                Url = "/api/v1/adminmodule/deletestaff",
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
                      message = "Staff Deleted successfully"
                  });

        }




        //Payment Bank



        /// <summary>
        /// This endpoint is used to create a new payment bank
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePaymentBank([FromBody] PaymentBankCreateModel model)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {

                var paymentBank = new TblPaymentBank
                {
                    PaymentBankCode = model.PaymentBankCode,
                    PaymentBankName = model.PaymentBankName,
                    CreatedDate = DateTime.Now,

                };
                await _paymentBankRepository.CreateAsync(paymentBank);
                // write logic to create TblAuthList object

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "PaymentBank",
                    Url = "/api/v1/adminmodule/createpaymentbank",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);

                // login for email notification
                var endPointId = await GetEndPointId(); 
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                await _auditRepository.SaveChangesAsync();

                return Ok(
                   new
                   {
                       message = "Payment Bank created successfully",
                       EmailAddress = emailAddress
                   });


            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });

        }



        /// <summary>
        /// This endpoint is used to update an existing payment bank with a specified Id in the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="paymentBankId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePaymentBank([FromBody] PaymentBankUpdateModel model, [FromQuery] int paymentBankId)
        {
            var userId = GetUserId();


            if (ModelState.IsValid)
            {
                var paymentBank = await _paymentBankRepository.GetByIdAsync(paymentBankId);

                if (paymentBank == null)
                {
                    return NotFound(new { message = "Payment Bank does not exist" });
                }


                // assign updated fields
                paymentBank.PaymentBankCode = model.PaymentBankCode;
                paymentBank.PaymentBankName = model.PaymentBankName;




                _paymentBankRepository.Update(paymentBank);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                // write logic to create TblAuthList object
                var newAudit = new TblAuthList
                {
                    Title = "PaymentBank",
                    Url = "/api/v1/adminmodule/updatepaymentbank",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);


                // login for email notification
                var endPointId = await GetEndPointId();
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                await _auditRepository.SaveChangesAsync();

                return Ok(
                   new
                   {
                       message = "Payment Bank updated successfully",
                       EmailAddress = emailAddress
                   });


            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });

        }





        /// <summary>
        /// This endpoint is used to get an existing payment bank with a specified Id in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(TblPaymentBank), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPaymentBank([FromQuery] int id)
        {
            var userId = GetUserId();

            var paymentBank = await _paymentBankRepository.GetByIdAsync(id);
            if (paymentBank == null)
            {
                return NotFound("Payment Bank does not exist");
            }


            // write logic to create TblAuthList object
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "PaymentBank",
                Url = "/api/v1/adminmodule/getpaymentbank",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(paymentBank);
        }





        /// <summary>
        /// This endpoint is used to get all payment banks in the database
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<TblPaymentBank>), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPaymentBanks()
        {
            var userId = GetUserId();

            var paymentBanks = await _paymentBankRepository.GetAllAsync();
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "PaymentBank",
                Url = "/api/v1/adminmodule/getallpaymentbanks",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(paymentBanks);

        }

        /// <summary>
        /// This endpoint is use to delete an existing payment bank with a specified Id in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePaymentBank([FromQuery] int id)
        {
            var userId = GetUserId();

            var paymentBank = await _paymentBankRepository.GetByIdAsync(id);
            if (paymentBank == null)
            {
                return NotFound("Payment Bank does not exist");
            }

            _paymentBankRepository.Delete(paymentBank);
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "PaymentBank",
                Url = "/api/v1/adminmodule/deletepaymentbank",
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
                      message = "Payment Bank Deleted successfully"
                  });

        }




        // Document Types

        /// <summary>
        /// This endpoint is used to create a new Document Type in the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateDocumentType([FromBody] DocumentTypeFormModel model)
        {
            var userId = GetUserId();
            var endPointId = await GetEndPointId();

            if (ModelState.IsValid)
            {

                var documentType = new TblDocumentType
                {
                    DocTypeName = model.DocTypeName,
                    DocTypeDescription = model.DocTypeDescription,
                    CreatedDate = DateTime.Now,
                };

                await _documentTypeRepository.CreateAsync(documentType);
                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

                // write logic to create TblAuthList object
                var newAudit = new TblAuthList
                {
                    Title = "Create Document Type",
                    Url = "/api/v1/adminmodule/createdocumenttype",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);

                // login for email notification

                //int endPointId = _workFlowRepository.Find(x => x.WFDefId == 1).FirstOrDefault().WFDefId;
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                await _auditRepository.SaveChangesAsync();

                return Ok(
                   new
                   {
                       message = "Document Type created successfully",
                       EmailAddress = emailAddress
                   });


            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });

        }



        /// <summary>
        /// This endpoint is used to update an existing document type with a specified Id in the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="documentTypeId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateDocumentType([FromBody] DocumentTypeFormModel model, [FromQuery] int documentTypeId)
        {
            var userId = GetUserId();
            var endPointId = await GetEndPointId();

            if (ModelState.IsValid)
            {
                var documentType = await _documentTypeRepository.GetByIdAsync(documentTypeId);

                if (documentType == null)
                {
                    return NotFound(new { message = "Document Type does not exist" });
                }

                // assign updated fields
                documentType.DocTypeName = model.DocTypeName;
                documentType.DocTypeDescription = model.DocTypeDescription;

                _documentTypeRepository.Update(documentType);
                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

                // write logic to create TblAuthList object
                var newAudit = new TblAuthList
                {
                    Title = "Update Document Type",
                    Url = "/api/v1/adminmodule/updatedocumenttype",
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
                       message = "Document Type updated successfully",
                       EmailAddress = emailAddress
                   });
            }


            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });

        }



        /// <summary>
        /// This endpoint is used to get an existing document type with a specified Id in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(TblDocumentType), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetDocumentType([FromQuery] int id)
        {
            var userId = GetUserId();

            var documentType = await _documentTypeRepository.GetByIdAsync(id);
            if (documentType == null)
            {
                return NotFound("Document Type does not exist");
            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Get Document Type",
                Url = "/api/v1/adminmodule/getdocumenttype",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(documentType);
        }



        /// <summary>
        /// This endpoint is used to get all Document types in the database
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<TblDocumentType>), 200)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDocumentTypes()
        {
            var userId = GetUserId();

            var documentTypes = await _documentTypeRepository.GetAllAsync();
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Get All Document Types",
                Url = "/api/v1/adminmodule/getalldocumenttypes",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(documentTypes);
        }




        /// <summary>
        /// This endpoint is used to get 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteDocumentType([FromQuery] int id)
        {
            var userId = GetUserId();

            var documentType = await _documentTypeRepository.GetByIdAsync(id);
            if (documentType == null)
            {
                return NotFound("Document Type does not exist");
            }

            _documentTypeRepository.Delete(documentType);
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "Delete Document Type",
                Url = "/api/v1/adminmodule/deletedocumenttype",
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
                      message = "Document Type Deleted successfully"
                  });

        }



        // Role Assignment
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            var userId = GetUserId();

            var defaultUsers = _userManager.GetUsersInRoleAsync("Staff").Result.ToList();
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            var newAudit = new TblAuthList
            {
                Title = "GetAllUsers",
                Url = "/api/v1/adminmodule/getallusers",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(defaultUsers);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> MakeAdmin([FromQuery] string email)
        {
            var userId = GetUserId();

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound(new
                {
                    message = "user was not found"
                });
            }

            await _userManager.AddToRoleAsync(user, "Admin");
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            var newAudit = new TblAuthList
            {
                Title = "MakeAdmin",
                Url = "/api/v1/adminmodule/makeadmin",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();


            return Ok(new
            {
                message = "Administrator role added to user successfully"
            });
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> MakeAuthorizer([FromQuery] string email)
        {
            var userId = GetUserId();

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound(new
                {
                    message = "user was not found"
                });
            }

            await _userManager.AddToRoleAsync(user, "Authorizer");
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            var newAudit = new TblAuthList
            {
                Title = "MakeAuthorizer",
                Url = "/api/v1/adminmodule/makeauthorizer",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(new
            {
                message = "Authorizer role added to user successfully"
            });
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> MakeChekcer([FromQuery] string email)
        {
            var userId = GetUserId();

            var user = await _userManager.FindByIdAsync(email);
            if (user == null)
            {
                return NotFound(new
                {
                    message = "user not found"
                });
            }

            await _userManager.AddToRoleAsync(user, "Checker");
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            var newAudit = new TblAuthList
            {
                Title = "MakeChecker",
                Url = "/api/v1/adminmodule/makechecker",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(new
            {
                message = "Checker role added to user successfully"
            });
        }



        // Approval WorkFlow
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAdminModuleCheckerStatus([FromBody] AuthStatusModel model)
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
                // email address to initiator
                var emailAddress = await _emailAddressRepository.SendEmailAddress(model.BatchId);
                // if checker status was not selected
                if (model.Status == 0)
                {
                    return BadRequest(new { message = "Status was not selected" });
                }

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
        public async Task<IActionResult> CreateAdminModuleAuthorizerStatus([FromBody] AuthStatusModel model, string authorizerCode)
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
