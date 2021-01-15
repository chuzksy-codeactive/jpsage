using AutoMapper;
using JPSAGE_ERP.Application.Models;
using JPSAGE_ERP.Domain.Entities;

namespace JPSAGE_ERP.Application.Profiles
{
    public class MiscellaneousProfile : Profile
    {
        public MiscellaneousProfile()
        {
            CreateMap<TblCompanyInfo, CompanyInfoDto>();
        }
    }
}
