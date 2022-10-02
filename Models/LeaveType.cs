using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BVPortalApi.Models
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public bool IsActive { get; set; }
    }
}