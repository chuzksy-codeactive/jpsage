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

        public async Task<List<string>> SendEmailAddress(int endPointId, int approvalId)
        {
            try
            {
                if (approvalId == 1)
                {
                    var staffRole = await _context.TblStaffRoles.SingleOrDefaultAsync(x => x.WfdefId == endPointId);

                    if (staffRole == null)
                    {
                        throw new ArgumentNullException(nameof(staffRole));
                    }

                    var checker = await _context.TblStaffBioData.FirstOrDefaultAsync(x => x.StaffId == staffRole.CheckerId);

                    EmailAddress.Add(checker.OfficeEmailAddress);

                }

                if (approvalId == 2)
                {
                    var staffRole = await _context.TblStaffRoles.SingleOrDefaultAsync(x => x.WfdefId == endPointId);

                    if (staffRole == null)
                    {
                        throw new ArgumentNullException(nameof(staffRole));
                    }

                    var authorizer = await _context.TblStaffBioData.FirstOrDefaultAsync(x => x.StaffId == staffRole.AuthoriserId);

                    EmailAddress.Add(authorizer.OfficeEmailAddress);
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
