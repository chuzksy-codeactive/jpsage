using AutoMapper;
using JPSAGE_ERP.Application.Models;
using JPSAGE_ERP.Application.Models.Account;
using JPSAGE_ERP.Application.Models.Responses;
using JPSAGE_ERP.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPSAGE_ERP.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/miscellaneous")]
    public class MiscellaneousController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MiscellaneousController(
            ApplicationDbContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Endpoint to get all roles
        /// </summary>
        /// <returns></returns>
        [HttpGet("getRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = new List<UserRoleDto>
            {
                new UserRoleDto { Id = "1", Name = "Admin" },
                new UserRoleDto { Id = "2", Name = "Checker" },
                new UserRoleDto { Id = "3", Name = "Authorizer" },
                new UserRoleDto { Id = "4", Name = "Staff" },
                new UserRoleDto { Id = "5", Name = "VendorAdmin" },
                new UserRoleDto { Id = "6", Name = "Vendor" }
            };

            return Ok(new SucessResponse<IEnumerable<UserRoleDto>>
            {
                success = true,
                message = "Roles retrieved successfully",
                data = roles
            });
        }

        /// <summary>
        /// Endpoint to get all companies
        /// </summary>
        /// <returns></returns>
        [HttpGet("getCompanies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _context.TblCompanyInfo.ToListAsync();

            var result = _mapper.Map<IEnumerable<CompanyInfoDto>>(companies);

            return Ok(new SucessResponse<IEnumerable<CompanyInfoDto>>
            {
                success = true,
                message = "Companies info retrieved successfully",
                data = result
            });
        }
    }
}
