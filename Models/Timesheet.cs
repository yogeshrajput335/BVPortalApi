using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BVPortalApi.Models
{
    public class Timesheet
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? FullName { get; set; }
        public int MasterId { get; set; }
        public string? Month{ get; set; }
        public string? Year { get; set; }
        public string? week { get; set; }
        public string? Status { get; set; }
        public bool IsActive { get; set; }
    }
}