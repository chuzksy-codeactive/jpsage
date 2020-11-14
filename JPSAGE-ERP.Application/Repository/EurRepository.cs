using JPSAGE_ERP.Application.Interfaces;
using JPSAGE_ERP.Domain;
using JPSAGE_ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPSAGE_ERP.Application.Repository
{
    public class EurRepository : Repository<TblPaymentRequestMaster>, IEurRepository
    {
        public EurRepository(ApplicationDbContext context) : base(context)
        {
        }


        /// <summary>
        /// Creates end user requisition form's checker status in the database mto form table.
        /// </summary>
        /// <param name="eurformId">Mto Form Id</param><param name="checkerStatus">Checker Approval Status</param>
        public async Task<string> RegisterEurFormCheckerStatus(int eurformId, int? checkerStatus)
        {
            try
            {
                var eurFormStatus = await _context.TblPaymentRequestMaster.Where(eurForm => eurForm.PayReqMasterId == eurformId)
                                                          .FirstOrDefaultAsync();

                //eurFormStatus.ApprovalStatus = checkerStatus;
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return "End user requistion form checker status registered.";
        }


        /// <summary>
        /// Creates End user requisition form's authorizer status in the database TblPaymentRequestMaster form table.
        /// </summary>
        /// <param name="eurformId">Mto Form Id</param><param name="authorizerStatus">Authorizer Approval Status</param>
        public async Task<string> RegisterEurFormAuthorizerStatus(int eurformId, int? authorizerStatus)
        {
            try
            {
                var eurFormStatus = await _context.TblPaymentRequestMaster.Where(eurForm => eurForm.PayReqMasterId == eurformId)
                                                          .FirstOrDefaultAsync();

                //eurFormStatus.FinalApproval = authorizerStatus;
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return "End user requistion form authorizer status registered.";
        }

        public async Task<TblPaymentRequestDetails> GetCorrespondingDetails(int id)
        {
            return await _context.TblPaymentRequestDetails.Where(x => x.PayReqMasterId == id).FirstOrDefaultAsync();
        }
    }
}
