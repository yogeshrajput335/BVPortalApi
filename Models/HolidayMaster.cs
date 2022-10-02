using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BVPortalApi.Models
{
    public class HolidayMaster
    {
        public int Id { get; set; }
        public string? HolidayName { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string? Status { get; set; }
        public bool IsActive { get; set; }
    }
}