using JPSAGE_ERP.Application.Interfaces;
using JPSAGE_ERP.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JPSAGE_ERP.Application.Models.ContractAward.FormListObjects;
using JPSAGE_ERP.Application.Models.ContractAward;
using JPSAGE_ERP.Application.Models.ApprovalWorkFlow;

namespace JPSAGE_ERP.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ContractAwardController : ControllerBase
    {
        private readonly IRepository<TblSupplierIdentification> _supplierRepository;
        private readonly IRepository<TblCurrency> _currencyRepository;
        private readonly IRepository<TblPurchaseOrder> _purchaseOrderRepository;
        private readonly IRepository<TblPurchaseOrderDetails> _purchaseOrderDetailsRepository;
        private readonly IRepository<TblQuotationMaster> _quotationMasterRepository;
        private readonly IRepository<TblAuthList> _auditRepository;
        private readonly IRepository<TblAuthChecker> _authCheckerRepository;
        private readonly IRepository<TblAuthApprover> _authApproverRepository;
        private readonly IRepository<TblStaffBioData> _staffRepository;
        private readonly IRepository<TblWorkflowProcessDef> _workFlowRepository;
        private readonly IRepository<TblCodeGenerator> _codeGeneratorRepository;
        private readonly IEmailAddressRepository _emailAddressRepository;

        public ContractAwardController(
            IRepository<TblSupplierIdentification> supplierRepository,
            IRepository<TblCurrency> currencyRepository,
            IRepository<TblPurchaseOrder> purchaseOrderRepository,
            IRepository<TblPurchaseOrderDetails> purchaseOrderDetailsRepository,
            IRepository<TblQuotationMaster> quotationMasterRepository,
            IRepository<TblAuthList> auditRepository,
            IRepository<TblAuthChecker> authCheckerRepository,
            IRepository<TblAuthApprover> authApproverRepository,
            IRepository<TblStaffBioData> staffRepository,
            IRepository<TblWorkflowProcessDef> workFlowRepository,
            IRepository<TblCodeGenerator> codeGeneratorRepository,
             IEmailAddressRepository emailAddressRepository)
        {
            _supplierRepository = supplierRepository;
            _currencyRepository = currencyRepository;
            _purchaseOrderRepository = purchaseOrderRepository;
            _purchaseOrderDetailsRepository = purchaseOrderDetailsRepository;
            _quotationMasterRepository = quotationMasterRepository;
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
            var tblWorkflow = await _workFlowRepository.FirstOrDefaultAsync(x => x.WfdefId == 8);
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
        public async Task<IActionResult> GetPurchaseOrderForm()
        {
            var userId = GetUserId();

            var PoTypes = new List<PoTypes>
            {
                new PoTypes{ Text = "Purchase Order above 7 million", Value = 0},
                new PoTypes{ Text = "Purchase Order below 7 million", Value = 1},
                new PoTypes{ Text = "Service Contract above 7 million", Value = 2},
            };

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "ContractAward",
                Url = "/api/v1/contractaward/getpurchaseorderform",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(new
            {
                QuotationMasters = await _quotationMasterRepository.GetAllAsync(),
                PoTypes,
                // write logic to get appropriate suppliers
                Suppliers = await _supplierRepository.GetAllAsync()
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> SubmitPurchaseOrderForm([FromBody] PurchaseOrderFormModel model)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {
                var newPurchaseOrder = new TblPurchaseOrder
                {
                    SupplierId = model.SupplierID,
                    IssuedDate = model.IssuedDate,
                    QuoteRef = model.QuoteRef,
                    Potype = model.POType,
                    Poamount = model.Poamount,
                    QuoMasterId = model.QuoMasterId,
                    CreatedDate = DateTime.Now
                };

                await _purchaseOrderRepository.CreateAsync(newPurchaseOrder);

                var endPointId = await GetEndPointId();

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "ContractAward",
                    Url = "/api/v1/contractaward/submitpurchaseorderform",
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
                        message = "Purchase order created successfully",
                        EmailAddress = emailAddress
                    });

            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> PurchaseOrderFormUpdate([FromBody] PurchaseOrderFormModel model, [FromQuery] int PoId)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {
                var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(PoId);

                if (purchaseOrder == null)
                {
                    return NotFound(new { message = "Purchase Order does not exist" });
                }

                //purchaseOrder.PoId = model.PoId;
                purchaseOrder.SupplierId = model.SupplierID;
                purchaseOrder.IssuedDate = model.IssuedDate;
                purchaseOrder.QuoteRef = model.QuoteRef;
                purchaseOrder.Potype = model.POType;

                _purchaseOrderRepository.Update(purchaseOrder);

                var endPointId = await GetEndPointId();

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "ContractAward",
                    Url = "/api/v1/contractaward/purchaseorderformupdate",
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
                        message = "purchase order updated successfully",
                        EmailAddress = emailAddress
                    });
            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPurchaseOrders()
        {
            var userId = GetUserId();


            var purchaseOrderList = _purchaseOrderRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "ContractAward",
                Url = "/api/v1/contractaward/getallpurchaseorders",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(purchaseOrderList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPurchaseOrder([FromQuery] int id)
        {

            var userId = GetUserId();

            var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(id);

            if (purchaseOrder == null)
            {
                return NotFound("Purchase order not found");
            }

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "ContractAward",
                Url = "/api/v1/contractaward/getpurchaseorder",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(purchaseOrder);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePurchaseOrder([FromQuery] int id)
        {
            var userId = GetUserId();

            var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound("Purchase Order does not exist");
            }

            _purchaseOrderRepository.Delete(purchaseOrder);

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "ContractAward",
                Url = "/api/v1/contractaward/deletepurchaseorder",
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
                      message = "Purchase Order Deleted successfully"
                  });
        }

        // Purchase order details
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPurchaseOrderDetailsForm()
        {
            var userId = GetUserId();


            var PaymentTypes = new List<PaymentTypes>
            {
                new PaymentTypes {Text = "Fixed", Value = 0},
                new PaymentTypes {Text = "Dynamic", Value = 1}
            };

            var DeliveryTerms = new List<DeliveryTerms>
            {
                new DeliveryTerms{ Text = "Partial Delivery", Value = 0},
                new DeliveryTerms{ Text = "Complete Delivery", Value = 1},
                new DeliveryTerms{ Text = "Milestone", Value = 2}
            };

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "ContractAward",
                Url = "/api/v1/contractaward/getpurchaseorderform",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(new
            {
                Currencies = await _currencyRepository.GetAllAsync(),
                PurchaseOrderList = await _purchaseOrderRepository.GetAllAsync(),
                PaymentTypes,
                DeliveryTerms
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> SubmitPurchaseOrderDetailsForm([FromBody] List<PurchaseOrderDetailsFormModel> models, [FromQuery] int PoId)
        {
            var userId = GetUserId();

            if (ModelState.IsValid)
            {
                var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(PoId);
                if (purchaseOrder == null)
                {
                    return BadRequest(new { message = "Purchase order not found" });
                }

                var previousPurchaseOrderDetails = await _purchaseOrderDetailsRepository.FindAsync(x => x.PoId == PoId);
                if (previousPurchaseOrderDetails.ToList().Count != 0)
                {
                    return BadRequest(new { message = "Purchase Order details already set for this purchase order" });
                }


                decimal totalAmount = 0;
                var podList = new List<TblPurchaseOrderDetails>();



                // Po low complexity
                if (purchaseOrder.Potype == 0)
                {
                    foreach (var model in models)
                    {
                        var newPurchaseOrderDetails = new TblPurchaseOrderDetails
                        {
                            PoId = PoId,
                            Description = model.Description,
                            Quantity = model.Quantity,
                            Rate = model.Rate,
                            Amount = model.Quantity * model.NoOfDays * model.UniCost,
                            Total = model.Total,
                            DeliveryTerms = model.DeliveryTerms,
                            DeliveryAddress = model.DeliveryAddress,
                            Title = model.Title,
                            Vat = model.VAT,
                            CurrencyId = model.CurrencyID,
                            SubTotal = model.SubTotal,
                            UnitCost = model.UniCost,
                            TotalCost = model.TotalCost,
                            NoOfDays = model.NoOfDays

                        };

                        totalAmount += newPurchaseOrderDetails.Amount.GetValueOrDefault();
                        podList.Add(newPurchaseOrderDetails);
                    }

                    if (totalAmount != purchaseOrder.Poamount)
                    {
                        return BadRequest(new { message = "Total Purchase Order details amount must be equal to Total Purchase order amount" });
                    }

                    foreach (var pod in podList)
                    {
                        await _purchaseOrderDetailsRepository.CreateAsync(pod);
                    }



                }
                // PO High Complexity
                if (purchaseOrder.Potype == 1)
                {
                    foreach (var model in models)
                    {
                        var newPurchaseOrderDetails = new TblPurchaseOrderDetails
                        {
                            PoId = PoId,
                            Description = model.Description,
                            Quantity = model.Quantity,
                            Rate = model.Rate,
                            Amount = model.Quantity * model.NoOfDays * model.UniCost,
                            Total = model.Total,
                            DeliveryTerms = model.DeliveryTerms,
                            DeliveryAddress = model.DeliveryAddress,
                            Title = model.Title,
                            Vat = model.VAT,
                            CurrencyId = model.CurrencyID,
                            SubTotal = model.SubTotal,
                            UnitCost = model.UniCost,
                            TotalCost = model.TotalCost,
                            NoOfDays = model.NoOfDays

                        };

                        totalAmount += newPurchaseOrderDetails.Amount.GetValueOrDefault();
                        podList.Add(newPurchaseOrderDetails);

                    }


                    foreach (var pod in podList)
                    {
                        await _purchaseOrderDetailsRepository.CreateAsync(pod);
                    }



                }

                // Service Contract
                if (purchaseOrder.Potype == 2)
                {
                    foreach (var model in models)
                    {
                        var newPurchaseOrderDetails = new TblPurchaseOrderDetails
                        {
                            PoId = PoId,
                            Description = model.Description,
                            Quantity = model.Quantity,
                            Rate = model.Rate,
                            Amount = model.UniCost,
                            Total = model.Total,
                            DeliveryTerms = model.DeliveryTerms,
                            DeliveryAddress = model.DeliveryAddress,
                            Title = model.Title,
                            Vat = model.VAT,
                            CurrencyId = model.CurrencyID,
                            SubTotal = model.SubTotal,
                            UnitCost = model.UniCost,
                            TotalCost = model.TotalCost,
                            NoOfDays = model.NoOfDays

                        };

                        totalAmount += newPurchaseOrderDetails.Amount.GetValueOrDefault();
                        podList.Add(newPurchaseOrderDetails);

                    }


                    foreach (var pod in podList)
                    {
                        await _purchaseOrderDetailsRepository.CreateAsync(pod);
                    }
                }

                var endPointId = await GetEndPointId();

                var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
                var newAudit = new TblAuthList
                {
                    Title = "ContractAward",
                    Url = "/api/v1/contractaward/submitpurchaseorderdetailsform",
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
                        message = "Purchase order details added successfully",
                        EmailAddress = emailAddress
                    });

            }

            return BadRequest(new
            {
                Errors = new[] { "Please input correct values" }
            });
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> PurchaseOrderDetailsUpdate([FromQuery] int PoId)
        {
            var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(PoId);
            if (purchaseOrder == null)
            {
                return NotFound(new { message = "Purchase Order does not exist" });
            }

            var podList = await _purchaseOrderDetailsRepository.FindAsync(x => x.PoId == PoId);

            return Ok(new { PurchaseOrderList = podList });
        }


        // this method might be required later

        //[HttpPut("[action]")]
        //public async Task<IActionResult> PurchaseOrderDetailsFormUpdate([FromBody] PurchaseOrderDetailsFormModel model, [FromQuery] int PoId)
        //{


        //    return BadRequest(new
        //    {
        //        Errors = new[] { "Please input correct values" }
        //    });
        //}



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPurchaseOrderDetails()
        {
            var userId = GetUserId();

            //var purchaseOrderList = new List<PurchaseOrderResponseObject>();

            var purchaseOrderList = await _purchaseOrderDetailsRepository.GetAllAsync();

            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            var newAudit = new TblAuthList
            {
                Title = "ContractAward",
                Url = "/api/v1/contractaward/getallpurchaseorders",
                CreatedDate = DateTime.Now,
                Status = 0,
                StaffId = tblStaff.StaffId,
                BatchId = Guid.NewGuid().ToString()
            };

            await _auditRepository.CreateAsync(newAudit);

            await _auditRepository.SaveChangesAsync();

            return Ok(purchaseOrderList);
        }





        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePurchaseOrderDetails([FromQuery] int id)
        {
            var userId = GetUserId();

            var purchaseOrderDetails = await _purchaseOrderDetailsRepository.GetByIdAsync(id);
            if (purchaseOrderDetails == null)
            {
                return NotFound("Purchase Order Details does not exist");
            }

            _purchaseOrderDetailsRepository.Delete(purchaseOrderDetails);
            var tblStaff = await _staffRepository.FirstOrDefaultAsync(x => x.AspnetUserId == userId);
            // write logic to create TblAuthList object
            var newAudit = new TblAuthList
            {
                Title = "ContractAward",
                Url = "/api/v1/contractaward/deletepurchaseorderdetails",
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
                      message = "Purchase Order Details Deleted successfully"
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
                    var codes = _codeGeneratorRepository.FindAsync(x => x.GeneratedCode == authorizerCode).Result.FirstOrDefault();
                    
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
