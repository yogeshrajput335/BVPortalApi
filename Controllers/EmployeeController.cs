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
    public class EmployeeController : ControllerBase
    {
        private readonly BVContext DBContext;

        public EmployeeController(BVContext DBContext)
        {
            this.DBContext = DBContext;
        }

        [HttpGet("GetEmployee")]
        public async Task<ActionResult<List<EmployeeDTO>>> Get()
        {
            var List = await DBContext.Employee.Select(
                s => new EmployeeDTO
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    EmployeeType = s.EmployeeType,
                    Status = s.Status
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

        [HttpPost("InsertEmployee")]
        public async Task < HttpStatusCode > InsertEmployee(EmployeeDTO s) {
            var entity = new Employee() {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    EmployeeType = s.EmployeeType,
                    Status = s.Status
            };
            DBContext.Employee.Add(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpPut("UpdateEmployee")]
        public async Task<HttpStatusCode> UpdateEmployee(EmployeeDTO Employee) {
            var entity = await DBContext.Employee.FirstOrDefaultAsync(s => s.Id == Employee.Id);
            entity.FirstName = Employee.FirstName;
            entity.LastName = Employee.LastName;
            entity.Email = Employee.Email;
            entity.PhoneNumber = Employee.PhoneNumber;
            entity.EmployeeType = Employee.EmployeeType;
            entity.Status = Employee.Status;
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        
        [HttpDelete("DeleteEmployee/{Id}")]
        public async Task < HttpStatusCode > DeleteEmployee(int Id) {
            var entity = new Employee() {
                Id = Id
            };
            DBContext.Employee.Attach(entity);
            DBContext.Employee.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpPost("SetClientPerHour/{Id}/{perHour}/{client}")]
        public async Task<HttpStatusCode> SetClientPerHour(int Id, int perHour, int client)
        {
            float oldPerHour = 0;
            var entity = await DBContext.EmpClientPerHour.FirstOrDefaultAsync(s => s.EmployeeId == Id && s.ClientId==client);
            if (entity == null)
            {
                EmpClientPerHour ct = new EmpClientPerHour();
                ct.EmployeeId = Id;
                ct.ClientId = client;
                ct.PerHour = perHour;
                DBContext.EmpClientPerHour.Add(ct);
            }
            else if (entity != null && entity.PerHour != perHour)
            {
                oldPerHour = entity.PerHour;
                entity.PerHour = perHour;
            }
            EmpClientPerHourHistory cth = new EmpClientPerHourHistory();
            cth.ClientId = client;
            cth.EmployeeId = Id;
            cth.OldPerHour = oldPerHour;
            cth.NewPerHour = perHour;
            cth.ReasonForChange = ""; // TODO
            cth.ChangeDate = DateTime.Now;
            cth.ChangeBy = ""; // TODO
            DBContext.EmpClientPerHourHistory.Add(cth);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpGet("GetEmpClientPerHourHistory/{id}")]
        public async Task<ActionResult<List<EmpClientPerHourHistory>>> GetEmpClientPerHourHistory(int id)
        {
            var List = await DBContext.EmpClientPerHourHistory.Where(x => x.EmployeeId == id).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }
        [HttpGet("GetEmpClientPerHour")]
        public async Task<ActionResult<List<EmpClientPerHour>>> GetEmpClientPerHour(int id)
        {
            var List = await DBContext.EmpClientPerHour.ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }
    }
}