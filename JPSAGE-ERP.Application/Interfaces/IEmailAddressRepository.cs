using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JPSAGE_ERP.Application.Interfaces
{
    public interface IEmailAddressRepository
    {
        Task<List<string>> SendEmailAddress(int EndPointId, int approvalId);
        Task<List<string>> SendEmailAddress(string batchId);
    }
}
