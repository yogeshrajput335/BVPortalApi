using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BVPortalApi.Models
{
    public class Openjobs
    {
        public int Id { get; set; }
        public string? JobName { get; set; }
        public string? Description { get; set; }
        public string? StartDate { get; set; }
        public string? Country { get; set; }
        public string? Status { get; set; }
        public bool IsActive { get; set; }
    }
}