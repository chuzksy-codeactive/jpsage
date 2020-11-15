using JPSAGE_ERP.Application.Interfaces;
using JPSAGE_ERP.Domain;
using JPSAGE_ERP.Domain.Entities;
using JPSAGE_ERP.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JPSAGE_ERP.Application.Repository
{
    public class MMRepository : Repository<TblJobCompletionCertificate>, IMMRepository
    {
        public MMRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<string> RegisterJCCFormAuthorizerStatus(int JCCID, int? authorizerStatus)
        {
            try
            {
                var poFormStatus = await _context.TblJobCompletionCertificate.Where(JCCForm => JCCForm.Jccid == JCCID)
                                                          .FirstOrDefaultAsync();

                //poFormStatus.FinalApproval = authorizerStatus;
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return "Job Completion Certificate form authoriser status registered.";
        }

        public async Task<string> RegisterJCCFormCheckerStatus(int JCCID, int? checkerStatus)
        {
            try
            {
                var poFormStatus = await _context.TblJobCompletionCertificate.Where(JCCForm => JCCForm.Jccid == JCCID)
                                                          .FirstOrDefaultAsync();

                //poFormStatus.ApprovalStatus = checkerStatus;
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return "Job Completion Certificate form checker status registered.";
        }
    }
}
