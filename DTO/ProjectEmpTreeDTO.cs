using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BVPortalApi.DTO
{
    public class ProjectEmpTreeDTO
    {
        public string? Name { get; set; }
        public List<ProjectEmpTreeDTO> Children { get; set; }
    }
}