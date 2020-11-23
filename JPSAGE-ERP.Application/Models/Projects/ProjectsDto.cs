using System;

namespace JPSAGE_ERP.Application.Models.Projects
{
    public class ProjectsDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
