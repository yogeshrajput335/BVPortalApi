using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BVPortalApi.DTO
{
    public class TimesheetDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public string EmployeeName{ get; set; }
        public string ProjectName { get; set; }
        public DateTime WeekEndingDate { get; set; }
        public string? Status { get; set; }
    }
}