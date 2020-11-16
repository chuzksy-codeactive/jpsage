using JPSAGE_ERP.Application.Interfaces;
using JPSAGE_ERP.Domain;
using JPSAGE_ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JPSAGE_ERP.Application.Repository
{
    public class ContractAwardRepository : Repository<TblPurchaseOrder>, IContractAwardRepository
    {
        public ContractAwardRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<string> RegisterCAFormAuthorizerStatus(int PoId, int? authorizerStatus)
        {
            try
            {
                var poFormStatus = await _context.TblPurchaseOrder.Where(eurForm => eurForm.PoId == PoId)
                                                          .FirstOrDefaultAsync();

                //poFormStatus.FinalApproval = authorizerStatus;
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return "Purchase order form authoriser status registered.";
        }

        public async Task<string> RegisterCAFormCheckerStatus(int PoId, int? checkerStatus)
        {
            try
            {
                var poFormStatus = await _context.TblPurchaseOrder.Where(eurForm => eurForm.PoId == PoId)
                                                          .FirstOrDefaultAsync();

                //poFormStatus.ApprovalStatus = checkerStatus;
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return "Purchase order form checker status registered.";
        }
    }
}
