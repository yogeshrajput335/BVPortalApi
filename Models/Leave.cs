using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BVPortalApi.Models
{
    public class Leave
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int UserId { get; set; }
        public string? LeaveType { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? Reason{ get; set; }
        public string? Status { get; set; }
        public bool IsActive { get; set; }
    }
}