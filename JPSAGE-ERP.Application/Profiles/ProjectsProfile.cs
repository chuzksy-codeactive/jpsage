using AutoMapper;
using JPSAGE_ERP.Application.Models.Projects;
using JPSAGE_ERP.Domain.Entities;

namespace JPSAGE_ERP.Application.Profiles
{
    public class ProjectsProfile : Profile
    {
        public ProjectsProfile()
        {
            CreateMap<TblProjects, ProjectsDto>();
        }
    }
}
