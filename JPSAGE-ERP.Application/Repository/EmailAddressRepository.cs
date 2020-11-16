using JPSAGE_ERP.Application.Interfaces;
using JPSAGE_ERP.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JPSAGE_ERP.Application.Repository
{
    public class EmailAddressRepository : IEmailAddressRepository
    {
        private readonly ApplicationDbContext _context;
        public EmailAddressRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        private List<string> EmailAddress { get; set; }

        public async Task<List<string>> SendEmailAddress(int EndPointId, int approvalId)
        {
            try
            {
                if (approvalId == 1)
                {
                    EmailAddress = await _context.TblStaffRoles.Where(emailGroup => emailGroup.WfdefId == EndPointId)
                                                             .Select(email => email.Checker)
                                                             .ToListAsync();

                }
                if (approvalId == 2)
                {
                    EmailAddress = await _context.TblStaffRoles.Where(emailGroup => emailGroup.WfdefId == EndPointId)
                                                             .Select(email => email.Authorizer)
                                                             .ToListAsync();
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return EmailAddress;
        }


        public async Task<List<string>> SendEmailAddress(string batchId)
        {
            try
            {
                var staffId = _context.TblAuthList.Where(x => x.BatchId == batchId).Select(email => email.StaffId).FirstOrDefault();
                EmailAddress = await _context.TblStaffBioData.Where(staff => staff.StaffId == staffId).Select(email => email.OfficeEmailAddress).ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return EmailAddress;
        }
    }
}
