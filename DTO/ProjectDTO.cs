using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BVPortalApi.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string? ProjectName{ get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public bool IsActive { get; set; }
    }
}