using JPSAGE_ERP.Application.Interfaces;
using JPSAGE_ERP.Application.Models.ApprovalWorkFlow;
using JPSAGE_ERP.Application.Models.InvoiceForPayment;
using JPSAGE_ERP.DataObjects.Admin.ListObjects;
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
    public class InvoiceController : ControllerBase
    {
        private readonly IRepository<TblPaymentRequestMaster> _paymentRequestMasterRepository;
        private readonly IRepository<TblPaymentRequestDetails> _paymentRequestDetailsRepository;
        private readonly IRepository<TblPaymentBank> _paymentBankRepository;
        private readonly IRepository<TblDepartments> _departmentRepository;
        private readonly IRepository<TblStaffBioData> _staffRepository;
        private readonly IRepository<TblPurchaseOrder> _purchaseOrderRepository;
        private readonly IRepository<TblInvoice> _invoiceRepository;
        private readonly IRepository<TblInvoiceDetails> _invoiceDetailsRepository;
        private readonly IRepository<TblInvoiceOtherInfo> _invoiceOtherInfoRepository;
        private readonly IRepository<TblPurchaseOrderMilestones> _milestoneRepository;
        private readonly IRepository<TblCompanyInfo> _companyRepository;
        private readonly IRepository<TblClients> _clientRepository;
        private readonly IRepository<TblAuthList> _auditRepository;
        private readonly IRepository<TblAuthChecker> _authCheckerRepository;
        private readonly IRepository<TblAuthApprover> _authApproverRepository;
        private readonly IRepository<TblWorkflowProcessDef> _workFlowRepository;
        private readonly IRepository<TblCodeGenerator> _codeGeneratorRepository;
        private readonly IEmailAddressRepository _emailAddressRepository;

        public InvoiceController(
            IRepository<TblPaymentRequestMaster> paymentRequestMasterRepository,
            IRepository<TblPaymentRequestDetails> paymentRequestDetailsRepository,
            IRepository<TblPaymentBank> paymentBankRepository,
            IRepository<TblDepartments> departmentRepository,
            IRepository<TblStaffBioData> staffRepository,
            IRepository<TblPurchaseOrder> purchaseOrderRepository,
            IRepository<TblInvoice> invoiceRepository,
            IRepository<TblInvoiceDetails> invoiceDetailsRepository,
            IRepository<TblInvoiceOtherInfo> invoiceOtherInfoRepository,
            IRepository<TblPurchaseOrderMilestones> milestoneRepository,
            IRepository<TblCompanyInfo> companyRepository,
            IRepository<TblClients> clientRepository,
            IRepository<TblAuthList> auditRepository,
            IRepository<TblAuthChecker> authCheckerRepository,
            IRepository<TblAuthApprover> authApproverRepository,
            IRepository<TblWorkflowProcessDef> workFlowRepository,
            IRepository<TblCodeGenerator> codeGeneratorRepository,
            IEmailAddressRepository emailAddressRepository)
        {
            _paymentRequestMasterRepository = paymentRequestMasterRepository;
            _paymentRequestDetailsRepository = paymentRequestDetailsRepository;
            _paymentBankRepository = paymentBankRepository;
            _departmentRepository = departmentRepository;
            _staffRepository = staffRepository;
            _purchaseOrderRepository = purchaseOrderRepository;
            _invoiceRepository = invoiceRepository;
            _invoiceDetailsRepository = invoiceDetailsRepository;
            _invoiceOtherInfoRepository = invoiceOtherInfoRepository;
            this._milestoneRepository = milestoneRepository;
            _companyRepository = companyRepository;
            _clientRepository = clientRepository;
            _auditRepository = auditRepository;
            this._authCheckerRepository = authCheckerRepository;
            this._authApproverRepository = authApproverRepository;
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
            var tblWorkflow = await _workFlowRepository.FirstOrDefaultAsync(x => x.WfdefId == 10);
            return tblWorkflow.WfdefId;
        }

        [NonAction]
        public async Task<string> GetAuthorizerCode()
        {
            var codeGenerator = await _codeGeneratorRepository.FirstOrDefaultAsync(x => x.Status == 0);

            return codeGenerator.GeneratedCode;
        }




        #endregion

        // GET: api/v1/EndUserRequisition
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllInvoice()
        {
            var userId = GetUserId();

            var invoiceList = await _invoiceRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/getallinvoice",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(invoiceList);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetInvoice([FromQuery] int id)
        {
            var userId = GetUserId();

            var invoice = await _invoiceRepository.GetByIdAsync(id);

            if (invoice == null)
            {
                return NotFound("Invoice does not exist");
            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/getinvoice",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(invoice);
        }




        /// <summary>
        /// This api gets a list of all payment banks and also a list of all the departments for the dropdown selection 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> InvoiceForm()
        {
            var userId = GetUserId();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/invoiceform",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            var Statuses = new List<StatusListObject>
            {
                new StatusListObject {Text = "Processing Request", Value = 0},
                new StatusListObject {Text = "Request has been processed", Value = 1}
            };

            return Ok(new
            {
                Clients = _clientRepository.GetAllAsync(),
                Companies = _companyRepository.GetAllAsync(),
                PurchaseOrders = _purchaseOrderRepository.GetAllAsync(),
                Statuses,
                Departments = _departmentRepository.GetAllAsync()
            });
        }



        /// <summary>
        /// This creates the end user requisition 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceFormModel model)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {

                var invoice = new TblInvoice
                {
                    ClientId = model.ClientId,
                    CompanyInfoId = model.CompanyInfoId,
                    IssuedBy = model.IssuedBy,
                    Attention = model.Attention,
                    Contact = model.Contact,
                    SupplierId = model.SupplierId,
                    PoId = model.PoId,
                    InvoiceNumber = model.InvoiceNumber,
                    DueDate = model.DueDate,
                    TaxIdnumber = model.TaxIdnumber,
                    VatregNumber = model.VatregNumber,
                    Vatrate = model.Vatrate,
                    ContractTitle = model.ContractTitle,
                };

                await _invoiceRepository.CreateAsync(invoice);

                var endPointId = await GetEndPointId();
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);
                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

                var newAudit = new TblAuthList
                {
                    Title = "InvoiceForPayment",
                    Url = "/api/v1/invoice/createinvoice",
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
                        message = "Invoice created successfully",
                        EmailAddress = emailAddress
                    });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }




        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateInvoice([FromBody] CreateInvoiceFormModel model, [FromQuery] int invoiceId)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {

                var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);

                if (invoice == null)
                {
                    return NotFound(new { message = "Invoice not found" });
                }


                invoice.ClientId = model.ClientId;
                invoice.CompanyInfoId = model.CompanyInfoId;
                invoice.IssuedBy = model.IssuedBy;
                invoice.Attention = model.Attention;
                invoice.Contact = model.Contact;
                invoice.SupplierId = model.SupplierId;
                invoice.PoId = model.PoId;
                invoice.InvoiceNumber = model.InvoiceNumber;
                invoice.DueDate = model.DueDate;
                invoice.TaxIdnumber = model.TaxIdnumber;
                invoice.VatregNumber = model.VatregNumber;
                invoice.Vatrate = model.Vatrate;
                invoice.ContractTitle = model.ContractTitle;


                _invoiceRepository.Update(invoice);


                var endPointId = await GetEndPointId();
                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

                var newAudit = new TblAuthList
                {
                    Title = "InvoiceForPayment",
                    Url = "/api/v1/invoice/updateinvoice",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);

                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                await _auditRepository.SaveChangesAsync();

                return Ok(
                    new
                    {
                        message = "Invoice Updated successfully",
                        EmailAddress = emailAddress
                    });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }





        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteInvoice([FromQuery] int id)
        {
            var userId = GetUserId();

            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null)
            {
                return NotFound("Invoice does not exist");
            }

            _invoiceRepository.Delete(invoice);

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/deleteinvoice",
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
                      message = "Invoice Deleted successfully"
                  });
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllInvoiceDetails()
        {
            var userId = GetUserId();

            var invoiceDetailsList = await _invoiceDetailsRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/getallinvoicedetails",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(invoiceDetailsList);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetInvoiceDetails([FromQuery] int id)
        {
            var userId = GetUserId();

            var invoiceDetails = await _invoiceDetailsRepository.GetByIdAsync(id);

            if (invoiceDetails == null)
            {
                return NotFound("Invoice Details does not exist");
            }


            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/getinvoicedetails",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(invoiceDetails);
        }




        /// <summary>
        /// This api gets a list of all payment banks and also a list of all the departments for the dropdown selection 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> InvoiceDetailsForm()
        {
            var userId = GetUserId();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/invoicedetailsform",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();


            return Ok(new
            {
                Invoices = _invoiceRepository.GetAllAsync(),
                Milestones = _milestoneRepository.GetAllAsync()
            });
        }



        /// <summary>
        /// This creates the end user requisition 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateInvoiceDetails([FromBody] InvoiceDetailsFormModel model)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {

                var invoiceDetails = new TblInvoiceDetails
                {
                    InvoiceId = model.InvoiceId,
                    Description = model.Description,
                    Amount = model.Amount,
                    AmountInWords = model.AmountInWords,
                    TotalAmount = model.TotalAmount
                };

                await _invoiceDetailsRepository.CreateAsync(invoiceDetails);

                var endPointId = await GetEndPointId();
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "InvoiceForPayment",
                    Url = "/api/v1/invoice/createinvoicedetails",
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
                        message = "Invoice Details created successfully",
                        EmailAddress = emailAddress
                    });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateInvoiceDetails([FromBody] InvoiceDetailsFormModel model, [FromQuery] int invoiceDetailsId)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {

                var invoiceDetails = await _invoiceDetailsRepository.GetByIdAsync(invoiceDetailsId);

                if (invoiceDetails == null)
                {
                    return NotFound(new { message = "Invoice Details not found" });
                }


                invoiceDetails.InvoiceId = model.InvoiceId;
                invoiceDetails.Description = model.Description;
                invoiceDetails.Amount = model.Amount;
                invoiceDetails.AmountInWords = model.AmountInWords;
                invoiceDetails.TotalAmount = model.TotalAmount;


                _invoiceDetailsRepository.Update(invoiceDetails);


                var endPointId = await GetEndPointId();

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "InvoiceForPayment",
                    Url = "/api/v1/invoice/updateinvoicedetails",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);
                await _auditRepository.SaveChangesAsync();

                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                return Ok(
                    new
                    {
                        message = "Invoice Details Updated successfully",
                        EmailAddress = emailAddress
                    });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteInvoiceDetails([FromQuery] int id)
        {
            var userId = GetUserId();

            var invoiceDetails = await _invoiceDetailsRepository.GetByIdAsync(id);
            if (invoiceDetails == null)
            {
                return NotFound("Invoice Details does not exist");
            }

            _invoiceDetailsRepository.Delete(invoiceDetails);

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/deleteinvoicedetails",
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
                      message = "Invoice Details Deleted successfully"
                  });

        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllInvoiceOtherInfo()
        {
            var userId = GetUserId();

            var invoiceOtherInfoList = await _invoiceOtherInfoRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/getallinvoiceotherinfo",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();


            return Ok(invoiceOtherInfoList);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetInvoiceOtherInfo([FromQuery] int id)
        {
            var userId = GetUserId();

            var invoiceOtherInfo = _invoiceOtherInfoRepository.GetByIdAsync(id);

            if (invoiceOtherInfo == null)
            {
                return NotFound("Invoice Other Info does not exist");
            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/getinvoiceotherinfo",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(invoiceOtherInfo);
        }




        /// <summary>
        /// This api gets a list of all payment banks and also a list of all the departments for the dropdown selection 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> InvoiceOtherInfoForm()
        {
            var userId = GetUserId();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/invoiceotherinfoform",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(new
            {
                Invoices = _invoiceRepository.GetAllAsync(),
                PaymentBanks = _paymentBankRepository.GetAllAsync()
            });
        }



        /// <summary>
        ///  
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateInvoiceOtherInfo([FromBody] InvoiceOtherInfoFormModel model)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {

                var invoiceOtherInfo = new TblInvoiceOtherInfo
                {
                    InvoiceId = model.InvoiceId,
                    PaymentBankId = model.PaymentBankId,
                    AccountDetails = model.AccountDetails,
                    AccountName = model.AccountName,
                    AccountNumber = model.AccountNumber,
                    SortCode = model.SortCode
                };

                await _invoiceOtherInfoRepository.CreateAsync(invoiceOtherInfo);

                var endPointId = await GetEndPointId();
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "InvoiceForPayment",
                    Url = "/api/v1/invoice/createinvoiceotherinfo",
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
                        message = "Invoice Other Info created successfully",
                        EmailAddress = emailAddress
                    });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }




        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateInvoiceOtherInfo([FromBody] InvoiceOtherInfoFormModel model, [FromQuery] int invoiceOtherInfoId)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {

                var invoiceOtherInfo = await _invoiceOtherInfoRepository.GetByIdAsync(invoiceOtherInfoId);

                if (invoiceOtherInfo == null)
                {
                    return NotFound(new { message = "Invoice Other Info not found" });
                }


                invoiceOtherInfo.InvoiceId = model.InvoiceId;
                invoiceOtherInfo.PaymentBankId = model.PaymentBankId;
                invoiceOtherInfo.AccountDetails = model.AccountDetails;
                invoiceOtherInfo.AccountNumber = model.AccountName;
                invoiceOtherInfo.AccountNumber = model.AccountNumber;
                invoiceOtherInfo.SortCode = model.SortCode;


                _invoiceOtherInfoRepository.Update(invoiceOtherInfo);

                var endPointId = await GetEndPointId();
                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);

                var newAudit = new TblAuthList
                {
                    Title = "InvoiceForPayment",
                    Url = "/api/v1/invoice/updateinvoiceotherinfo",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);
                await _auditRepository.SaveChangesAsync();

                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                return Ok(
                    new
                    {
                        message = "Invoice Other info Updated successfully",
                        EmailAddress = emailAddress
                    });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }







        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteInvoiceOtherInfo([FromQuery] int id)
        {
            var userId = GetUserId();

            var invoiceOtherInfo = await _invoiceOtherInfoRepository.GetByIdAsync(id);
            if (invoiceOtherInfo == null)
            {
                return NotFound("Invoice does not exist");
            }

            _invoiceOtherInfoRepository.Delete(invoiceOtherInfo);

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/deleteinvoiceotherinfo",
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
                      message = "Invoice Other Info Deleted successfully"
                  });

        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPaymentRequestMaster()
        {
            var userId = GetUserId();

            var mastersList = await _paymentRequestMasterRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/getallpaymentrequestmaster",
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
        public async Task<IActionResult> GetPaymentRequestMaster([FromQuery] int id)
        {
            var userId = GetUserId();

            var payRequestMaster = await _paymentRequestMasterRepository.GetByIdAsync(id);

            if (payRequestMaster == null)
            {
                return NotFound("Payment Request master does not exist");
            }


            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/getpaymentrequestmaster",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(payRequestMaster);
        }




        /// <summary>
        /// This api gets a list of all payment banks and also a list of all the departments for the dropdown selection 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> PaymentRequestMasterForm()
        {
            var userId = GetUserId();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/paymentrequestmasterform",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(new
            {
                PurchaseOrders = await _purchaseOrderRepository.GetAllAsync(),
                PaymentBanks = await _paymentBankRepository.GetAllAsync(),
                Departments = await _departmentRepository.FindAsync(x => x.DepartmentId >= 10)
            });
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePaymentRequestMaster([FromBody] PaymentRequestMasterFormModel model)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {
                if (model.PaymentBankId == 0 || model.DepartmentProject == 0)
                {

                    return BadRequest(new
                    {
                        Errors = new[] { "Department  and Payment Bank  required" }
                    });

                }

                var paymentRequestMaster = new TblPaymentRequestMaster
                {
                    PoId = model.PoId,
                    PaymentBankId = model.PaymentBankId,
                    Payee = model.Payee,
                    AccountNumber = model.AccountNumber,
                    DepartmentProject = model.DepartmentProject,
                    PayReqDate = model.PayReqDate,
                    PayReqNumber = model.PayReqNumber
                };

                await _paymentRequestMasterRepository.CreateAsync(paymentRequestMaster);

                var endPointId = await GetEndPointId();
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "InvoiceForPayment",
                    Url = "/api/v1/invoice/createpaymentrequestmaster",
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
                        message = "Payment request master created successfully",
                        EmailAddress = emailAddress
                    });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }




        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePaymentRequestMaster([FromBody] PaymentRequestMasterFormModel model, [FromQuery] int PaymentRequestMasterId)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {
                //var paymentRequestMaster = _mapper.Map<TblPaymentRequestMaster>(model);

                if (model.PaymentBankId == 0 || model.DepartmentProject == 0)
                {

                    return BadRequest(new
                    {
                        Errors = new[] { "Department  and Payment Bank  required" }
                    });

                }

                var paymentRequestMaster = await _paymentRequestMasterRepository.GetByIdAsync(PaymentRequestMasterId);

                if (paymentRequestMaster == null)
                {
                    return NotFound(new { message = "Payment Request Master not found" });
                }


                paymentRequestMaster.PaymentBankId = model.PaymentBankId;
                paymentRequestMaster.Payee = model.Payee;
                paymentRequestMaster.AccountNumber = model.AccountNumber;
                paymentRequestMaster.DepartmentProject = model.DepartmentProject;
                paymentRequestMaster.PayReqDate = model.PayReqDate;
                paymentRequestMaster.PayReqNumber = model.PayReqNumber;



                _paymentRequestMasterRepository.Update(paymentRequestMaster);


                var endPointId = await GetEndPointId();

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "InvoiceForPayment",
                    Url = "/api/v1/invoice/updatepaymentrequestmaster",
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StaffId = tblStaff.StaffId,
                    BatchId = Guid.NewGuid().ToString()
                };

                await _auditRepository.CreateAsync(newAudit);

                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                await _auditRepository.SaveChangesAsync();

                return Ok(
                    new
                    {
                        message = "Payment request master Updated successfully",
                        EmailAddress = emailAddress
                    });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }


        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePaymentRequestMaster([FromQuery] int id)
        {
            var userId = GetUserId();

            var paymentRequestMaster = await _paymentRequestMasterRepository.GetByIdAsync(id);
            if (paymentRequestMaster == null)
            {
                return NotFound("Payment Request Master does not exist");
            }

            _paymentRequestMasterRepository.Delete(paymentRequestMaster);

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/deletepaymentrequestmaster",
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
                      message = "Payment Request Master Deleted successfully"
                  });

        }




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPaymentRequestDetails()
        {
            var userId = GetUserId();

            var detailsList = await _paymentRequestDetailsRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/getallpaymentrequestdetails",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(detailsList);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPaymentRequestDetails([FromQuery] int id)
        {
            var userId = GetUserId();

            var payRequestDetails = await _paymentRequestDetailsRepository.GetByIdAsync(id);

            if (payRequestDetails == null)
            {
                return NotFound("Payment Request Details does not exist");
            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/getpaymentrequestdetails",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(payRequestDetails);
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetPaymentRequestDetailsByMasterId([FromQuery] int id)
        {
            var userId = GetUserId();

            var payRequestDetails = _paymentRequestMasterRepository.FindAsync(x => x.PayReqMasterId == id);

            if (payRequestDetails == null)
            {
                return NotFound("Payment Request Details does not exist");
            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/getpaymentrequestdetailsbymasterid",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(payRequestDetails);
        }




        /// <summary>
        /// This api gets a list of all payment banks and also a list of all the departments for the dropdown selection 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> PaymentRequestDetailsForm()
        {
            var userId = GetUserId();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/paymentrequestdetailsform",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);
            await _auditRepository.SaveChangesAsync();

            return Ok(new
            {
                PaymentRequestMastersList = await _paymentRequestMasterRepository.GetAllAsync()
            });
        }






        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePaymentRequestDetails([FromBody] PaymentRequestDetailsFormModel model)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {
                //var paymentRequestMaster = _mapper.Map<TblPaymentRequestMaster>(model);

                if (model.PayReqMasterId == 0)
                {

                    return BadRequest(new
                    {
                        Errors = new[] { "Payment Request Master Id required" }
                    });

                }

                var paymentRequestDetails = new TblPaymentRequestDetails
                {
                    PayReqMasterId = model.PayReqMasterId,
                    Description = model.Description,
                    GlaccountCode = model.GlaccountCode,
                    Amount = model.Amount,
                    TotalAmount = model.TotalAmount,
                    AmountInWords = model.AmountInWords
                };

                await _paymentRequestDetailsRepository.CreateAsync(paymentRequestDetails);


                var endPointId = await GetEndPointId();
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "InvoiceForPayment",
                    Url = "/api/v1/invoice/createpaymentrequestdetails",
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
                        message = "Payment request details created successfully",
                        EmailAddress = emailAddress
                    });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }




        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePaymentRequestDetails([FromBody] PaymentRequestDetailsFormModel model, [FromQuery] int paymentRequestDetailsId)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {
                if (paymentRequestDetailsId == 0)
                {

                    return BadRequest(new
                    {
                        Errors = new[] { "Payment Request Details Id required" }
                    });

                }
                var paymentRequestDetails = await _paymentRequestDetailsRepository.GetByIdAsync(paymentRequestDetailsId);

                if (paymentRequestDetails == null)
                {

                }

                paymentRequestDetails.PayReqMasterId = model.PayReqMasterId;
                paymentRequestDetails.Description = model.Description;
                paymentRequestDetails.GlaccountCode = model.GlaccountCode;
                paymentRequestDetails.Amount = model.Amount;
                paymentRequestDetails.TotalAmount = model.TotalAmount;

                _paymentRequestDetailsRepository.Update(paymentRequestDetails);


                var endPointId = await GetEndPointId();
                var emailAddress = await _emailAddressRepository.SendEmailAddress(endPointId, 1);

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "InvoiceForPayment",
                    Url = "/api/v1/invoice/updatepaymentrequestdetails",
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
                        message = "Payment request details updated successfully",
                        EmailAddress = emailAddress
                    });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }


        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePaymentRequestDetails([FromQuery] int id)
        {
            var userId = GetUserId();

            var paymentRequestDetails = await _paymentRequestDetailsRepository.GetByIdAsync(id);
            if (paymentRequestDetails == null)
            {
                return NotFound("Payment Request Details does not exist");
            }

            _paymentRequestDetailsRepository.Delete(paymentRequestDetails);

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "InvoiceForPayment",
                Url = "/api/v1/invoice/deletepaymentrequestdetails",
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
                      message = "Payment Request Details Deleted successfully"
                  });
        }

        // Approval WorkFlow
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateInvoiceModuleCheckerStatus([FromBody] AuthStatusModel model)
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
        public async Task<IActionResult> CreateInvoiceModuleAuthorizerStatus([FromBody] AuthStatusModel model, string authorizerCode)
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
