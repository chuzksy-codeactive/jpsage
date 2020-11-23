using AutoMapper;
using JPSAGE_ERP.Application.Interfaces;
using JPSAGE_ERP.Application.Models.Projects;
using JPSAGE_ERP.Application.Models.Responses;
using JPSAGE_ERP.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPSAGE_ERP.WebAPI.Controllers
{
    [Route("api/v1/projects")]
    [ApiController]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IRepository<TblProjects> _tblProjects;
        private readonly IMapper _mapper;
        public ProjectsController(IRepository<TblProjects> tblProjects,
            IMapper mapper)
        {
            _tblProjects = tblProjects;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(SucessResponse<IEnumerable<ProjectsDto>>), 200)]
        public async Task<IActionResult> GetProjects()
        {
            try
            {
                var projects = await _tblProjects.GetAllAsync();

                var projectsDto = _mapper.Map<IEnumerable<ProjectsDto>>(projects);

                return Ok(new SucessResponse<IEnumerable<ProjectsDto>>
                {
                    success = true,
                    message = "Projects retrieved successfully",
                    data = projectsDto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, Response<string>.InternalError(ex.Message));
            }
        }
    }
}
