using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BVPortalApi.CommonFeatures;
using BVPortalApi.CommonFeatures.Contracts;
using BVPortalApi.DTO;
using BVPortalApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BVPortalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimesheetController : ControllerBase
    {
        private readonly BVContext DBContext;

        public TimesheetController(BVContext DBContext)
        {
            this.DBContext = DBContext;
        }
        [HttpGet("GetTimesheet")]
        public async Task<ActionResult<List<TimesheetDTO>>> Get()
        {
            var List = await DBContext.Timesheet.Select(
                s => new TimesheetDTO
                {
                    Id = s.Id,
                    UserId = s.UserId,
                    FullName=s.FullName,
                    MasterId = s.MasterId,
                    Month=s.Month,
                    Year=s.Year,
                    Week=s.week,
                    Status = s.Status,
                    IsActive = s.IsActive
                }
            ).ToListAsync();
            
            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }
        [HttpPost("InsertTimesheet")]
        public async Task < HttpStatusCode > InsertTimesheet(TimesheetDTO s) {
            var entity = new Timesheet() {
                    UserId = s.UserId,
                    FullName=s.FullName,
                    MasterId = s.MasterId,
                    Month=s.Month,
                    Year=s.Year,
                    week=s.Week,
                    Status = s.Status,
                    IsActive = s.IsActive
            };
            DBContext.Timesheet.Add(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpPut("UpdateTimesheet")]
        public async Task<HttpStatusCode> UpdateTimesheet(TimesheetDTO Timesheet) {
            var entity = await DBContext.Timesheet.FirstOrDefaultAsync(s => s.Id == Timesheet.Id);
            entity.UserId = Timesheet.UserId;
            entity.FullName = Timesheet.FullName;
            entity.MasterId = Timesheet.MasterId;
            entity.Month = Timesheet.Month;
            entity.Year = Timesheet.Year;
            entity.week = Timesheet.Week;
            entity.Status = Timesheet.Status;
            entity.IsActive = Timesheet.IsActive;
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        [HttpDelete("DeleteTimesheet/{Id}")]
        public async Task < HttpStatusCode > DeleteTimesheet(int Id) {
            var entity = new Timesheet() {
                Id = Id
            };
            DBContext.Timesheet.Attach(entity);
            DBContext.Timesheet.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}